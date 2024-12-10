namespace BTreeDB
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            AddBTN = new Button();
            DeleteBTN = new Button();
            ChangeBTN = new Button();
            FindBTN = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            KeyNUD = new NumericUpDown();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            ValueLB = new Label();
            ValueTB = new TextBox();
            ClearBTN = new Button();
            TableDataLV = new ListView();
            Key = new ColumnHeader();
            Value = new ColumnHeader();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)KeyNUD).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Controls.Add(TableDataLV, 0, 0);
            tableLayoutPanel1.Location = new Point(9, 9);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1246, 663);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel3.Controls.Add(ClearBTN, 0, 2);
            tableLayoutPanel3.Location = new Point(996, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Size = new Size(248, 207);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(AddBTN, 0, 0);
            tableLayoutPanel4.Controls.Add(DeleteBTN, 1, 0);
            tableLayoutPanel4.Controls.Add(ChangeBTN, 0, 1);
            tableLayoutPanel4.Controls.Add(FindBTN, 1, 1);
            tableLayoutPanel4.Location = new Point(0, 69);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(248, 69);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // AddBTN
            // 
            AddBTN.Location = new Point(3, 3);
            AddBTN.Name = "AddBTN";
            AddBTN.Size = new Size(118, 28);
            AddBTN.TabIndex = 1;
            AddBTN.Text = "Add";
            AddBTN.UseVisualStyleBackColor = true;
            AddBTN.Click += AddBTN_Click;
            // 
            // DeleteBTN
            // 
            DeleteBTN.Location = new Point(127, 3);
            DeleteBTN.Name = "DeleteBTN";
            DeleteBTN.Size = new Size(118, 28);
            DeleteBTN.TabIndex = 0;
            DeleteBTN.Text = "Delete";
            DeleteBTN.UseVisualStyleBackColor = true;
            DeleteBTN.Click += RemoveBTN_Click;
            // 
            // ChangeBTN
            // 
            ChangeBTN.Location = new Point(3, 37);
            ChangeBTN.Name = "ChangeBTN";
            ChangeBTN.Size = new Size(118, 29);
            ChangeBTN.TabIndex = 1;
            ChangeBTN.Text = "Change";
            ChangeBTN.UseVisualStyleBackColor = true;
            ChangeBTN.Click += ChangeBTN_Click;
            // 
            // FindBTN
            // 
            FindBTN.Location = new Point(127, 37);
            FindBTN.Name = "FindBTN";
            FindBTN.Size = new Size(118, 29);
            FindBTN.TabIndex = 2;
            FindBTN.Text = "Find";
            FindBTN.UseVisualStyleBackColor = true;
            FindBTN.Click += FindBTN_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(248, 69);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(KeyNUD, 0, 1);
            tableLayoutPanel6.Controls.Add(label1, 0, 0);
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Margin = new Padding(0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.Size = new Size(124, 69);
            tableLayoutPanel6.TabIndex = 4;
            // 
            // KeyNUD
            // 
            KeyNUD.Location = new Point(3, 43);
            KeyNUD.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            KeyNUD.Name = "KeyNUD";
            KeyNUD.Size = new Size(118, 23);
            KeyNUD.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 25);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 5;
            label1.Text = "Key";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(ValueLB, 0, 0);
            tableLayoutPanel2.Controls.Add(ValueTB, 0, 1);
            tableLayoutPanel2.Location = new Point(124, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 57.9710159F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 42.0289841F));
            tableLayoutPanel2.Size = new Size(124, 69);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // ValueLB
            // 
            ValueLB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ValueLB.AutoSize = true;
            ValueLB.Location = new Point(3, 25);
            ValueLB.Name = "ValueLB";
            ValueLB.Size = new Size(118, 15);
            ValueLB.TabIndex = 6;
            ValueLB.Text = "Value";
            ValueLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ValueTB
            // 
            ValueTB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ValueTB.Location = new Point(3, 43);
            ValueTB.Name = "ValueTB";
            ValueTB.PlaceholderText = "Value";
            ValueTB.Size = new Size(118, 23);
            ValueTB.TabIndex = 4;
            // 
            // ClearBTN
            // 
            ClearBTN.Location = new Point(3, 141);
            ClearBTN.Name = "ClearBTN";
            ClearBTN.Size = new Size(242, 63);
            ClearBTN.TabIndex = 2;
            ClearBTN.Text = "Clear";
            ClearBTN.UseVisualStyleBackColor = true;
            ClearBTN.Click += ClearBTN_Click;
            // 
            // TableDataLV
            // 
            TableDataLV.Columns.AddRange(new ColumnHeader[] { Key, Value });
            TableDataLV.GridLines = true;
            TableDataLV.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            TableDataLV.Location = new Point(0, 0);
            TableDataLV.Margin = new Padding(0);
            TableDataLV.MultiSelect = false;
            TableDataLV.Name = "TableDataLV";
            TableDataLV.Size = new Size(996, 663);
            TableDataLV.TabIndex = 6;
            TableDataLV.UseCompatibleStateImageBehavior = false;
            TableDataLV.View = View.Details;
            TableDataLV.SelectedIndexChanged += TableDataLV_SelectedIndexChanged;
            TableDataLV.KeyDown += TableDataLV_KeyDown;
            // 
            // Key
            // 
            Key.Tag = "";
            Key.Text = "Key";
            // 
            // Value
            // 
            Value.Text = "Value";
            Value.Width = 355;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "SDB";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)KeyNUD).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ListView TableDataLV;
        private ColumnHeader Key;
        private ColumnHeader Value;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button AddBTN;
        private Button DeleteBTN;
        private Button ChangeBTN;
        private Button FindBTN;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private NumericUpDown KeyNUD;
        private Label label1;
        private Button ClearBTN;
        private TableLayoutPanel tableLayoutPanel2;
        private Label ValueLB;
        private TextBox ValueTB;
    }
}
