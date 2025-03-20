namespace AlarmClockApp
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
            lblClock = new Label();
            lblStatus = new Label();
            btnStart = new Button();
            txtAlarmTime = new TextBox();
            btnStopAlarm = new Button();
            SuspendLayout();
            // 
            // lblClock
            // 
            lblClock.Font = new Font("Arial", 40F, FontStyle.Bold);
            lblClock.Location = new Point(63, 67);
            lblClock.Margin = new Padding(5, 0, 5, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(390, 128);
            lblClock.TabIndex = 0;
            lblClock.Text = "当前时间";
            lblClock.Click += lblClock_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblStatus.Location = new Point(485, 81);
            lblStatus.Margin = new Padding(5, 0, 5, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(218, 33);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "当前状态：计时";
            lblStatus.Click += lblStatus_Click;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(485, 226);
            btnStart.Margin = new Padding(5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(152, 40);
            btnStart.TabIndex = 2;
            btnStart.Text = "设置闹钟";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtAlarmTime
            // 
            txtAlarmTime.Font = new Font("Arial", 10F);
            txtAlarmTime.Location = new Point(63, 226);
            txtAlarmTime.Margin = new Padding(5);
            txtAlarmTime.Name = "txtAlarmTime";
            txtAlarmTime.Size = new Size(390, 30);
            txtAlarmTime.TabIndex = 3;
            txtAlarmTime.Text = "输入闹钟时间(格式为HH:mm:ss)";
            txtAlarmTime.TextChanged += txtAlarmTime_TextChanged;
            // 
            // btnStopAlarm
            // 
            btnStopAlarm.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnStopAlarm.Location = new Point(485, 118);
            btnStopAlarm.Margin = new Padding(5);
            btnStopAlarm.Name = "btnStopAlarm";
            btnStopAlarm.Size = new Size(140, 33);
            btnStopAlarm.TabIndex = 4;
            btnStopAlarm.Text = "停止响铃";
            btnStopAlarm.UseVisualStyleBackColor = true;
            btnStopAlarm.Click += btnStopAlarm_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 360);
            Controls.Add(btnStopAlarm);
            Controls.Add(txtAlarmTime);
            Controls.Add(btnStart);
            Controls.Add(lblStatus);
            Controls.Add(lblClock);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "闹钟程序";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtAlarmTime;
        private System.Windows.Forms.Button btnStopAlarm;
    }
}