using System;
using System.Timers;
using System.Windows.Forms;

namespace AlarmClockApp
{
    public partial class Form1 : Form
    {
        private AlarmClock _alarmClock;
        private TimeDisplay _timeDisplay;
        private AlarmInputValidator _inputValidator;
        private System.Timers.Timer _timeUpdateTimer;
        private bool _isAlarmSet = false;
        private bool _isAlarmRinging = false;

        public Form1()
        {
            InitializeComponent();
            _alarmClock = new AlarmClock();
            _timeDisplay = new TimeDisplay(lblClock);
            _inputValidator = new AlarmInputValidator();

            _alarmClock.Tick += AlarmClock_Tick;
            _alarmClock.Alarm += AlarmClock_Alarm;

            _timeDisplay.UpdateTimeDisplay();

            // ������ʱ������ʱ��
            _timeUpdateTimer = new System.Timers.Timer(1000);
            _timeUpdateTimer.Elapsed += (sender, e) => _timeDisplay.UpdateTimeDisplay();
            _timeUpdateTimer.Start();
        }

        private void AlarmClock_Tick(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                _timeDisplay.UpdateTimeDisplay();
                if (!_isAlarmRinging)
                {
                    lblStatus.Text = "��ǰ״̬����ʱ";
                }
            });
        }

        private void AlarmClock_Alarm(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblStatus.Text = "��ǰ״̬������";
                _isAlarmRinging = true;
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime alarmTime;
                if (_inputValidator.TryParseAlarmTime(txtAlarmTime.Text, out alarmTime))
                {
                    _alarmClock.AlarmTime = alarmTime;
                    _alarmClock.Start();
                    _isAlarmSet = true;
                }
                else
                {
                    MessageBox.Show("��������ȷ��ʱ���ʽ��HH:mm:ss����");
                }
            }
            catch
            {
                MessageBox.Show("����δ֪���������ԡ�");
            }
        }

        private void btnStopAlarm_Click(object sender, EventArgs e)
        {
            if (_isAlarmRinging)
            {
                lblStatus.Text = "��ǰ״̬����ʱ";
                _isAlarmRinging = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ��ʼ���߼�
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // �����߼�
        }

        private void txtAlarmTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime alarmTime;
                if (_inputValidator.TryParseAlarmTime(txtAlarmTime.Text, out alarmTime))
                {
                    if (_isAlarmSet)
                    {
                        _alarmClock.AlarmTime = alarmTime;
                    }
                }
            }
            catch
            {
                // �ȴ��û�������ȷ��ʽ
            }
        }

        private void lblClock_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }

    public class AlarmClock
    {
        private System.Timers.Timer _timer;
        public DateTime AlarmTime { get; set; }

        public event EventHandler? Tick;
        public event EventHandler? Alarm;

        public AlarmClock()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Tick?.Invoke(this, EventArgs.Empty);
            if (DateTime.Now.Hour == AlarmTime.Hour &&
                DateTime.Now.Minute == AlarmTime.Minute &&
                DateTime.Now.Second == AlarmTime.Second)
            {
                Alarm?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public class TimeDisplay
    {
        private Label _label;

        public TimeDisplay(Label label)
        {
            _label = label;
        }

        public void UpdateTimeDisplay()
        {
            _label.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }

    public class AlarmInputValidator
    {
        public bool TryParseAlarmTime(string input, out DateTime alarmTime)
        {
            return DateTime.TryParseExact(input, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out alarmTime);
        }
    }
}