public class AlarmClock
{
    // 定时器
    private System.Timers.Timer _timer;
    // 闹钟时间
    public DateTime AlarmTime { get; set; }

    // 定时器 Tick 事件
    public event EventHandler? Tick;
    // 闹钟触发事件
    public event EventHandler? Alarm;

    public AlarmClock()
    {
        // 创建定时器，每隔 1 秒触发一次
        _timer = new System.Timers.Timer(1000);
        // 订阅定时器的 Elapsed 事件
        _timer.Elapsed += Timer_Elapsed;
    }

    public void Start()
    {
        // 启动定时器
        _timer.Start();
    }

    public void Stop()
    {
        // 停止定时器
        _timer.Stop();
    }

    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // 触发 Tick 事件
        Tick?.Invoke(this, EventArgs.Empty);
        // 判断当前时间是否等于闹钟时间
        if (DateTime.Now.Hour == AlarmTime.Hour &&
            DateTime.Now.Minute == AlarmTime.Minute &&
            DateTime.Now.Second == AlarmTime.Second)
        {
            // 触发闹钟事件
            Alarm?.Invoke(this, EventArgs.Empty);
        }
    }
}