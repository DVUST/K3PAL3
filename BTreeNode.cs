namespace BTreeDB
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class BTreeNode(int minDegree, bool isLeaf, string path)
    {
        public List<(int, string)> Keys { get; set; } = [];
        public List<BTreeNode> Childrens { get; set; } = [];
        public bool IsLeaf { get; set; } = isLeaf;
        public int MinDegree { get; set; } = minDegree;
        public string Path { get; } = path;

        public void Save()
        {
            using StreamWriter writer = new(Path);
            writer.Write(Serialize());
        }

        public static BTreeNode Load(string path, int minDegree)
        {
            using StreamReader reader = new(path);
            return Deserialize(reader.ReadToEnd(), minDegree, path);
        }

        private string Serialize()
        {
            var result = $"{IsLeaf}\n";
            result += $"{Keys.Count}\n";
            result += Keys.Count > 0 ? string.Join("\n", Keys.Select(k => $"{k.Item1} {k.Item2}")) + "\n" : "";
            result += $"{Childrens.Count}\n";
            result += string.Join("\n", Childrens);
            return result;
        }

        private static BTreeNode Deserialize(string data, int minDegree, string path)
        {
            var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var isLeaf = bool.Parse(lines[0]);

            var node = new BTreeNode(minDegree, isLeaf, path);

            int KeysCount = int.Parse(lines[1]);
            for (int i = 0; i < KeysCount; i++)
            {
                var keyParts = lines[2 + i].Split(' ');
                node.Keys.Add((int.Parse(keyParts[0]), keyParts[1]));
            }

            int childrenCount = int.Parse(lines[2 + KeysCount]);
            for (int i = 0; i < childrenCount; i++)
            {
                node.Childrens.Add(Load(lines[3 + KeysCount + i], minDegree));
            }

            return node;
        }

        public string? GetValueOnIndex(int? index)
        {
            if (index is null) return null;
            return Keys[(int)index].Item2;
        }

        public void ChangeOnIndex(int? index, string value)
        {
            if (index is null) return;
            Keys[(int)index] = (Keys[(int)index].Item1, value);
        }

        public int FindIndex(int key)
        {
            int low = 0, high = Keys.Count-1;
            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (Keys[mid].Item1 == key)
                {
                    return mid;
                }
                else if (Keys[mid].Item1 < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }
    }
}
