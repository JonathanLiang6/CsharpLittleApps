namespace TextFileMerger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectFile1 = new Button();
            btnSelectFile2 = new Button();
            txtFilePath1 = new TextBox();
            txtFilePath2 = new TextBox();
            btnMergeFiles = new Button();
            lblStatus = new Label();
            btnOpenMergedFile = new Button();
            SuspendLayout();
            // 
            // btnSelectFile1
            // 
            btnSelectFile1.Font = new Font("Microsoft YaHei UI", 18F);
            btnSelectFile1.Location = new Point(93, 44);
            btnSelectFile1.Margin = new Padding(6);
            btnSelectFile1.Name = "btnSelectFile1";
            btnSelectFile1.Size = new Size(375, 75);
            btnSelectFile1.TabIndex = 0;
            btnSelectFile1.Text = "选择第一个文件";
            btnSelectFile1.UseVisualStyleBackColor = true;
            btnSelectFile1.Click += btnSelectFile1_Click;
            // 
            // btnSelectFile2
            // 
            btnSelectFile2.Font = new Font("Microsoft YaHei UI", 18F);
            btnSelectFile2.Location = new Point(93, 145);
            btnSelectFile2.Margin = new Padding(6);
            btnSelectFile2.Name = "btnSelectFile2";
            btnSelectFile2.Size = new Size(375, 75);
            btnSelectFile2.TabIndex = 1;
            btnSelectFile2.Text = "选择第二个文件";
            btnSelectFile2.UseVisualStyleBackColor = true;
            btnSelectFile2.Click += btnSelectFile2_Click;
            // 
            // txtFilePath1
            // 
            txtFilePath1.Font = new Font("Microsoft YaHei UI", 12F);
            txtFilePath1.Location = new Point(501, 65);
            txtFilePath1.Margin = new Padding(6);
            txtFilePath1.Name = "txtFilePath1";
            txtFilePath1.ReadOnly = true;
            txtFilePath1.Size = new Size(695, 38);
            txtFilePath1.TabIndex = 2;
            // 
            // txtFilePath2
            // 
            txtFilePath2.Font = new Font("Microsoft YaHei UI", 12F);
            txtFilePath2.Location = new Point(501, 166);
            txtFilePath2.Margin = new Padding(6);
            txtFilePath2.Name = "txtFilePath2";
            txtFilePath2.ReadOnly = true;
            txtFilePath2.Size = new Size(695, 38);
            txtFilePath2.TabIndex = 3;
            // 
            // btnMergeFiles
            // 
            btnMergeFiles.Font = new Font("Microsoft YaHei UI", 20F);
            btnMergeFiles.Location = new Point(165, 277);
            btnMergeFiles.Margin = new Padding(6);
            btnMergeFiles.Name = "btnMergeFiles";
            btnMergeFiles.Size = new Size(253, 75);
            btnMergeFiles.TabIndex = 4;
            btnMergeFiles.Text = "合并文件";
            btnMergeFiles.UseVisualStyleBackColor = true;
            btnMergeFiles.Click += btnMergeFiles_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft YaHei UI", 12F);
            lblStatus.Location = new Point(501, 321);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(134, 31);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "请选择文件";
            lblStatus.Click += lblStatus_Click;
            // 
            // btnOpenMergedFile
            // 
            btnOpenMergedFile.Enabled = false;
            btnOpenMergedFile.Font = new Font("Microsoft YaHei UI", 20F);
            btnOpenMergedFile.Location = new Point(406, 386);
            btnOpenMergedFile.Margin = new Padding(6);
            btnOpenMergedFile.Name = "btnOpenMergedFile";
            btnOpenMergedFile.Size = new Size(343, 70);
            btnOpenMergedFile.TabIndex = 6;
            btnOpenMergedFile.Text = "打开合并文件";
            btnOpenMergedFile.UseVisualStyleBackColor = true;
            btnOpenMergedFile.Click += btnOpenMergedFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 510);
            Controls.Add(btnOpenMergedFile);
            Controls.Add(lblStatus);
            Controls.Add(btnMergeFiles);
            Controls.Add(txtFilePath2);
            Controls.Add(txtFilePath1);
            Controls.Add(btnSelectFile2);
            Controls.Add(btnSelectFile1);
            Margin = new Padding(6);
            Name = "Form1";
            Text = "FileMerger";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile1;
        private System.Windows.Forms.Button btnSelectFile2;
        private System.Windows.Forms.TextBox txtFilePath1;
        private System.Windows.Forms.TextBox txtFilePath2;
        private System.Windows.Forms.Button btnMergeFiles;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnOpenMergedFile; // 新增按钮成员
    }
}