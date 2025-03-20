using System;
using System.Windows.Forms;

// 时间显示类，负责将当前时间显示在界面上
public class TimeDisplay
{
    // 时钟标签
    private Label _clockLabel;

    public TimeDisplay(Label clockLabel)
    {
        // 初始化时钟标签
        _clockLabel = clockLabel;
    }

    // 更新时间显示的方法
    public void UpdateTimeDisplay()
    {
        // 更新时钟标签的文本为当前时间
        _clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
    }
}