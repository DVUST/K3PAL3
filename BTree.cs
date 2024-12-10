namespace BTreeDB
{
    using System;
    using System.IO;

    public class BTree
    {
        private string DataPath;
        private string RootPath { get; set; }
        private int NodesCount { get; set; } = 0;
        private int T { get; set; }
        private BTreeNode Root { get; set; }

        public BTree(int t, string dataPath)
        {
            T = t;
            DataPath = dataPath;
            Reset();
        }

        public BTree(string path)
        {
            using StreamReader reader = new(path);
            Deserialize(reader.ReadToEnd());
        }

        private string GeneratePath()
        {
            return $"{DataPath}{NodesCount++}.txt";
        }

        public void Insert(int key, string value)
        {
            if (Search(key) is not null) return;
            var root = Root;

            if (root.Keys.Count == 2 * T - 1)
            {
                var newRoot = new BTreeNode(T, false, GeneratePath());
                newRoot.Childrens.Add(root);

                SplitChild(newRoot, 0, root);

                Root = newRoot;
                Save();

                InsertNonFull(newRoot, key, value);
            }
            else
            {
                InsertNonFull(root, key, value);
            }
        }

        private void InsertNonFull(BTreeNode node, int key, string value)
        {
            int i = node.Keys.Count - 1;

            if (node.IsLeaf)
            {
                node.Keys.Add((0, ""));
                while (i >= 0 && key < node.Keys[i].Item1)
                {
                    node.Keys[i + 1] = node.Keys[i];
                    i--;
                }
                node.Keys[i + 1] = (key, value);
                node.Save();
            }
            else
            {
                i = node.FindIndex(key);
                var child = node.Childrens[i];
                if (child.Keys.Count == 2 * T - 1)
                {
                    SplitChild(node, i, child);

                    if (key > node.Keys[i].Item1)
                    {
                        i++;
                    }
                }

                InsertNonFull(node.Childrens[i], key, value);
            }
        }

        private void SplitChild(BTreeNode parent, int index, BTreeNode fullChild)
        {
            var newChild = new BTreeNode(T, fullChild.IsLeaf, GeneratePath());

            newChild.Keys.AddRange(fullChild.Keys.GetRange(T, T - 1));
            fullChild.Keys.RemoveRange(T, T - 1);

            if (!fullChild.IsLeaf)
            {
                newChild.Childrens.AddRange(fullChild.Childrens.GetRange(T, T));
                fullChild.Childrens.RemoveRange(T, T);
            }

            parent.Keys.Insert(index, fullChild.Keys[T - 1]);
            fullChild.Keys.RemoveAt(T - 1);

            parent.Childrens.Insert(index + 1, newChild);

            fullChild.Save();
            newChild.Save();
            parent.Save();
        }

        public (BTreeNode, int)? Search(int key)
        {
            return Search(Root, key);
        }

        private static (BTreeNode, int)? Search(BTreeNode node, int key)
        {
            int index = BinarySearch(node, key);

            if (index >= 0 && index < node.Keys.Count && node.Keys[index].Item1 == key)
            {
                return (node, index);
            }

            if (node.IsLeaf)
            {
                return null;
            }

            return Search(node.Childrens[index >= 0 ? index : ~index], key);
        }

        private static int BinarySearch(BTreeNode node, int key)
        {
            int low = 0, high = node.Keys.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (node.Keys[mid].Item1 == key)
                {
                    return mid;
                }
                else if (node.Keys[mid].Item1 < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return ~low;
        }


        public void Reset()
        {
            if (Directory.Exists(DataPath))
            {
                foreach (var file in Directory.EnumerateFiles(DataPath))
                {
                    File.Delete(file);
                }                
            }
            NodesCount = 0;
            RootPath = GeneratePath();
            Root = new BTreeNode(T, true, RootPath);
            Root.Save();
            Save();
        }

        public void Delete(int key)
        {
            if (Search(key) is null) return;

            Delete(Root, key);

            if (Root.Keys.Count == 0 && !Root.IsLeaf)
            {
                Root = Root.Childrens[0];
            }

            Save();
        }

        private void Delete(BTreeNode node, int key)
        {
            int idx = node.Keys.FindIndex(k => k.Item1 >= key);

            if (idx < node.Keys.Count && node.Keys[idx].Item1 == key)
            {
                if (node.IsLeaf)
                {
                    node.Keys.RemoveAt(idx);
                    node.Save();
                }
                else
                {
                    DeleteInternalNode(node, idx);
                }
            }
            else if (!node.IsLeaf)
            {
                var child = node.Childrens[idx];
                if (child.Keys.Count < T)
                {
                    Fill(node, idx);
                }

                Delete(node.Childrens[idx], key);
            }
        }

        private void DeleteInternalNode(BTreeNode node, int idx)
        {
            var key = node.Keys[idx];

            if (node.Childrens[idx].Keys.Count >= T)
            {
                var predecessor = GetPredecessor(node.Childrens[idx]);
                node.Keys[idx] = predecessor;
                Delete(node.Childrens[idx], predecessor.Item1);
            }
            else if (node.Childrens[idx +1].Keys.Count >= T)
            {
                var successor = GetSuccessor(node.Childrens[idx +1]);
                node.Keys[idx] = successor;
                Delete(node.Childrens[idx +1], successor.Item1);
            }
            else
            {
                Merge(node, idx);
                Delete(node.Childrens[idx], key.Item1);
            }
        }

        private static void Merge(BTreeNode parent, int idx)
        {
            var child = parent.Childrens[idx];
            var sibling = parent.Childrens[idx +1];

            child.Keys.Add(parent.Keys[idx]);
            child.Keys.AddRange(sibling.Keys);
            child.Childrens.AddRange(sibling.Childrens);

            parent.Keys.RemoveAt(idx);
            parent.Childrens.RemoveAt(idx + 1);

            child.Save();
            sibling.Save();
            parent.Save();
        }

        private void Fill(BTreeNode parent, int idx)
        {
            if (idx > 0 && parent.Childrens[idx -1].Keys.Count >= T)
            {
                BorrowFromPrev(parent, idx);
            }
            else if (idx < parent.Childrens.Count - 1 && parent.Childrens[idx +1].Keys.Count >= T)
            {
                BorrowFromNext(parent, idx);
            }
            else
            {
                Merge(parent, idx > 0 ? idx - 1 : idx);
            }
        }

        private static void BorrowFromPrev(BTreeNode parent, int idx)
        {
            var child = parent.Childrens[idx];
            var sibling = parent.Childrens[idx -1];

            child.Keys.Insert(0, parent.Keys[idx - 1]);
            parent.Keys[idx - 1] = sibling.Keys[^1];
            sibling.Keys.RemoveAt(sibling.Keys.Count - 1);

            if (!child.IsLeaf)
            {
                child.Childrens.Insert(0, sibling.Childrens[^1]);
                sibling.Childrens.RemoveAt(sibling.Childrens.Count - 1);
            }

            child.Save();
            sibling.Save();
            parent.Save();
        }

        private static void BorrowFromNext(BTreeNode parent, int idx)
        {
            var child = parent.Childrens[idx];
            var sibling = parent.Childrens[idx +1];

            child.Keys.Add(parent.Keys[idx]);
            parent.Keys[idx] = sibling.Keys[0];
            sibling.Keys.RemoveAt(0);

            if (!child.IsLeaf)
            {
                child.Childrens.Add(sibling.Childrens[0]);
                sibling.Childrens.RemoveAt(0);
            }

            child.Save();
            sibling.Save();
            parent.Save();
        }

        private static (int, string) GetPredecessor(BTreeNode node)
        {
            while (!node.IsLeaf)
            {
                node = node.Childrens[^1];
            }
            return node.Keys[^1];
        }

        private static (int, string) GetSuccessor(BTreeNode node)
        {
            while (!node.IsLeaf)
            {
                node = node.Childrens[0];
            }
            return node.Keys[0];
        }

        public void Save()
        {
            if (!Directory.Exists(DataPath))
                Directory.CreateDirectory(DataPath);
            using StreamWriter writer = new($"{DataPath}root.txt");
            writer.Write(Serialize());
        }

        private string Serialize()
        {
            return $"{DataPath}\n{T}\n{Root.Path}\n{NodesCount}\n";
        }

        private void Deserialize(string data)
        {
            var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            DataPath = lines[0];
            T = int.Parse(lines[1]);
            RootPath = lines[2];
            NodesCount = int.Parse(lines[3]);
            Root = BTreeNode.Load(RootPath, T);
        }

        public List<(int, string)> Traverse()
        {
            return Traverse(Root);
        }

        private static List<(int, string)> Traverse(BTreeNode node)
        {
            List<(int, string)> result = [];

            for (int i = 0; i < node.Keys.Count; i++)
            {
                if (!node.IsLeaf)
                {
                    result.AddRange(Traverse(node.Childrens[i]));
                }

                result.Add((node.Keys[i].Item1, node.Keys[i].Item2));
            }

            if (!node.IsLeaf)
            {
                result.AddRange(Traverse(node.Childrens[^1]));
            }

            return result;
        }
    }
}
