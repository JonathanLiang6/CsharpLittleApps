namespace CalculatorApp
{
    partial class CalculatorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnDecimal = new System.Windows.Forms.Button();
            this.btnClearEntry = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBackspace = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // txtDisplay
            this.txtDisplay.BackColor = System.Drawing.Color.White;
            this.txtDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplay.Location = new System.Drawing.Point(0, 0);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(300, 38);
            this.txtDisplay.TabIndex = 0;
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // lblHistory
            this.lblHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblHistory.Location = new System.Drawing.Point(0, 38);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(300, 20);
            this.lblHistory.TabIndex = 1;
            this.lblHistory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // tableLayoutPanel1
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btn7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn8, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDivide, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnMultiply, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSubtract, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn0, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDecimal, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnClearEntry, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnBackspace, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnEquals, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 342);
            this.tableLayoutPanel1.TabIndex = 2;

            // 初始化所有按钮
            InitializeButton(btn7, "7");
            InitializeButton(btn8, "8");
            InitializeButton(btn9, "9");
            InitializeButton(btnDivide, "÷");
            InitializeButton(btn4, "4");
            InitializeButton(btn5, "5");
            InitializeButton(btn6, "6");
            InitializeButton(btnMultiply, "×");
            InitializeButton(btn1, "1");
            InitializeButton(btn2, "2");
            InitializeButton(btn3, "3");
            InitializeButton(btnSubtract, "-");
            InitializeButton(btn0, "0");
            InitializeButton(btnDecimal, ".");
            InitializeButton(btnClearEntry, "CE");
            InitializeButton(btnAdd, "+");
            InitializeButton(btnBackspace, "⌫");
            InitializeButton(btnEquals, "=");

            // 设置运算符按钮颜色
            btnAdd.BackColor = Color.LightGray;
            btnSubtract.BackColor = Color.LightGray;
            btnMultiply.BackColor = Color.LightGray;
            btnDivide.BackColor = Color.LightGray;
            btnEquals.BackColor = Color.Orange;

            // 设置等号按钮跨列
            this.tableLayoutPanel1.SetColumnSpan(btnEquals, 3);

            // CalculatorForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.txtDisplay);
            this.Name = "CalculatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeButton(Button button, string text)
        {
            button.Dock = DockStyle.Fill;
            button.Font = new Font("Microsoft Sans Serif", 12F);
            button.Margin = new Padding(1);
            button.Text = text;
            button.UseVisualStyleBackColor = false;

            if (text == "0" || text == "1" || text == "2" || text == "3" ||
                text == "4" || text == "5" || text == "6" || text == "7" ||
                text == "8" || text == "9")
            {
                button.Click += NumberButton_Click;
            }
            else if (text == "+" || text == "-" || text == "×" || text == "÷")
            {
                button.Click += OperatorButton_Click;
                button.BackColor = Color.LightGray;
            }
            else if (text == "=")
            {
                button.Click += btnEquals_Click;
                button.BackColor = Color.Orange;
            }
            else if (text == "CE")
            {
                button.Click += btnClearEntry_Click;
            }
            else if (text == ".")
            {
                button.Click += btnDecimal_Click;
            }
            else if (text == "⌫")
            {
                button.Click += btnBackspace_Click;
            }
        }

        #endregion

        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnDecimal;
        private System.Windows.Forms.Button btnClearEntry;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBackspace;
        private System.Windows.Forms.Button btnEquals;
    }
}