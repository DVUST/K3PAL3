using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace BTreeDB
{
    public partial class MainForm : Form
    {
        private const string DefaultPath = "./data/root.txt";
        private const int DefaultT = 100;
        private readonly BTree Table;

        public MainForm()
        {
            InitializeComponent();
            if (File.Exists(DefaultPath))
                Table = new(DefaultPath);
            else
                Table = new(DefaultT, DefaultPath);
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            Table.Insert((int)KeyNUD.Value, ValueTB.Text);;
            ValueTB.Text = "";
            UpdateDataList();
        }

        private void RemoveBTN_Click(object sender, EventArgs e)
        {
            Table.Delete((int)KeyNUD.Value);
            UpdateDataList();
        }

        private int FindKeyIndex(decimal keyToFind)
        {
            int low = 0, high = TableDataLV.Items.Count - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                var midItem = decimal.Parse(TableDataLV.Items[mid].Text);

                if (midItem == keyToFind)
                {
                    return mid;
                }
                else if (midItem < keyToFind)
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

        private void FindBTN_Click(object sender, EventArgs e)
        {
            TableDataLV.SelectedIndices.Clear();

            int index = FindKeyIndex(KeyNUD.Value);
            

            if (decimal.Parse(TableDataLV.Items[index].Text) == KeyNUD.Value)
            {
                TableDataLV.SelectedIndices.Add(index);

                var found = Table.Search((int)KeyNUD.Value);
                if (found?.Item1 is null)
                    ValueTB.Text = "";
                else
                    ValueTB.Text = found?.Item1.GetValueOnIndex(found?.Item2);
            }
            else
                ValueTB.Text = "";
        }

        private void ChangeBTN_Click(object sender, EventArgs e)
        {
            var found = Table.Search((int)KeyNUD.Value);
            found?.Item1.ChangeOnIndex(found?.Item2, ValueTB.Text);
            ValueTB.Text = "";
            UpdateDataList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TableDataLV.Columns[1].Width = TableDataLV.Width - TableDataLV.Columns[0].Width - 4;
            TableDataLV.FullRowSelect = true;
            UpdateDataList();
        }

        private void TableDataLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                KeyNUD.Value = int.Parse(TableDataLV.SelectedItems[0].Text.Split(":")[0].Trim());
            }
            catch (ArgumentOutOfRangeException) { };
        }

        private void UpdateDataList()
        {
            TableDataLV.Items.Clear();
            foreach (var item in Table.Traverse())
            {
                TableDataLV.Items.Add(new ListViewItem([item.Item1.ToString(), item.Item2]));
            }
        }

        private void ClearBTN_Click(object sender, EventArgs e)
        {
            bool confirmation = MessageBox.Show("Are you sure. Current table will be dropped.", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK;
            if (confirmation)
            {
                Table.Reset();
            }
            UpdateDataList();
        }

        private void TableDataLV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveBTN_Click(sender, e);
            }
        }
    }
}
