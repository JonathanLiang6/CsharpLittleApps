namespace LittleSearcher
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            searchTextBox = new TextBox();
            searchButton = new Button();
            lengthLabel = new Label();
            lengthNumeric = new NumericUpDown();
            historyComboBox = new ComboBox();
            clearHistoryButton = new Button();
            splitContainer = new SplitContainer();
            baiduGroup = new GroupBox();
            baiduTextBox = new RichTextBox();
            bingGroup = new GroupBox();
            bingTextBox = new RichTextBox();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            topPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)lengthNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            baiduGroup.SuspendLayout();
            bingGroup.SuspendLayout();
            statusStrip.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.ColumnCount = 6;
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            topPanel.Controls.Add(searchTextBox, 0, 0);
            topPanel.Controls.Add(searchButton, 1, 0);
            topPanel.Controls.Add(lengthLabel, 2, 0);
            topPanel.Controls.Add(lengthNumeric, 3, 0);
            topPanel.Controls.Add(historyComboBox, 4, 0);
            topPanel.Controls.Add(clearHistoryButton, 5, 0);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(10, 10);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(0, 0, 0, 10);
            topPanel.RowCount = 1;
            topPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            topPanel.Size = new Size(964, 45);
            topPanel.TabIndex = 0;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Location = new Point(3, 8);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(428, 23);
            searchTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.None;
            searchButton.Location = new Point(437, 6);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(84, 27);
            searchButton.TabIndex = 1;
            searchButton.Text = "搜索";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // lengthLabel
            // 
            lengthLabel.Anchor = AnchorStyles.Right;
            lengthLabel.AutoSize = true;
            lengthLabel.Location = new Point(527, 11);
            lengthLabel.Name = "lengthLabel";
            lengthLabel.Size = new Size(68, 17);
            lengthLabel.TabIndex = 2;
            lengthLabel.Text = "结果长度：";
            // 
            // lengthNumeric
            // 
            lengthNumeric.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lengthNumeric.Location = new Point(597, 8);
            lengthNumeric.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            lengthNumeric.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            lengthNumeric.Name = "lengthNumeric";
            lengthNumeric.Size = new Size(74, 23);
            lengthNumeric.TabIndex = 3;
            lengthNumeric.Value = new decimal(new int[] { 200, 0, 0, 0 });
            // 
            // historyComboBox
            // 
            historyComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            historyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            historyComboBox.FormattingEnabled = true;
            historyComboBox.Location = new Point(677, 8);
            historyComboBox.Name = "historyComboBox";
            historyComboBox.Size = new Size(194, 25);
            historyComboBox.TabIndex = 4;
            // 
            // clearHistoryButton
            // 
            clearHistoryButton.Anchor = AnchorStyles.None;
            clearHistoryButton.Location = new Point(877, 6);
            clearHistoryButton.Name = "clearHistoryButton";
            clearHistoryButton.Size = new Size(84, 27);
            clearHistoryButton.TabIndex = 5;
            clearHistoryButton.Text = "清除历史";
            clearHistoryButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(10, 55);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(baiduGroup);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(bingGroup);
            splitContainer.Size = new Size(964, 568);
            splitContainer.SplitterDistance = 482;
            splitContainer.TabIndex = 1;
            // 
            // baiduGroup
            // 
            baiduGroup.Controls.Add(baiduTextBox);
            baiduGroup.Dock = DockStyle.Fill;
            baiduGroup.Location = new Point(0, 0);
            baiduGroup.Name = "baiduGroup";
            baiduGroup.Padding = new Padding(10);
            baiduGroup.Size = new Size(482, 568);
            baiduGroup.TabIndex = 0;
            baiduGroup.Text = "百度搜索结果";
            // 
            // baiduTextBox
            // 
            baiduTextBox.BackColor = Color.White;
            baiduTextBox.BorderStyle = BorderStyle.None;
            baiduTextBox.Dock = DockStyle.Fill;
            baiduTextBox.Location = new Point(10, 26);
            baiduTextBox.Name = "baiduTextBox";
            baiduTextBox.ReadOnly = true;
            baiduTextBox.Size = new Size(462, 532);
            baiduTextBox.TabIndex = 0;
            baiduTextBox.Text = "";
            // 
            // bingGroup
            // 
            bingGroup.Controls.Add(bingTextBox);
            bingGroup.Dock = DockStyle.Fill;
            bingGroup.Location = new Point(0, 0);
            bingGroup.Name = "bingGroup";
            bingGroup.Padding = new Padding(10);
            bingGroup.Size = new Size(478, 568);
            bingGroup.TabIndex = 0;
            bingGroup.Text = "必应搜索结果";
            // 
            // bingTextBox
            // 
            bingTextBox.BackColor = Color.White;
            bingTextBox.BorderStyle = BorderStyle.None;
            bingTextBox.Dock = DockStyle.Fill;
            bingTextBox.Location = new Point(10, 26);
            bingTextBox.Name = "bingTextBox";
            bingTextBox.ReadOnly = true;
            bingTextBox.Size = new Size(458, 532);
            bingTextBox.TabIndex = 0;
            bingTextBox.Text = "";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(10, 623);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(964, 22);
            statusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(32, 17);
            statusLabel.Text = "就绪";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 655);
            Controls.Add(splitContainer);
            Controls.Add(topPanel);
            Controls.Add(statusStrip);
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "增强版多搜索引擎";
            ((System.ComponentModel.ISupportInitialize)lengthNumeric).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            baiduGroup.ResumeLayout(false);
            bingGroup.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel topPanel;
        private TextBox searchTextBox;
        private Button searchButton;
        private Label lengthLabel;
        private NumericUpDown lengthNumeric;
        private ComboBox historyComboBox;
        private Button clearHistoryButton;
        private SplitContainer splitContainer;
        private GroupBox baiduGroup;
        private RichTextBox baiduTextBox;
        private GroupBox bingGroup;
        private RichTextBox bingTextBox;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
    }
} 