using System;

// 闹钟输入验证类，验证用户输入的闹钟时间格式
public class AlarmInputValidator
{
    public bool TryParseAlarmTime(string input, out DateTime alarmTime)
    {
        try
        {
            // 尝试将输入的字符串解析为 DateTime 类型
            alarmTime = DateTime.ParseExact(input, "HH:mm:ss", null);
            return true;
        }
        catch (FormatException)
        {
            // 输入格式错误，返回 false
            alarmTime = DateTime.MinValue;
            return false;
        }
    }
}