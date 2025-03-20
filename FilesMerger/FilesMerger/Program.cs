using System;
using System.Windows.Forms;

namespace TextFileMerger
{
    // 程序入口类，包含程序的主方法
    static class Program
    {
        // 应用程序的主入口点
        [STAThread]
        static void Main()
        {
            // 设置应用程序的视觉样式，使其具有操作系统的外观
            Application.EnableVisualStyles();
            // 设置文本呈现默认值，确保文本显示一致
            Application.SetCompatibleTextRenderingDefault(false);
            // 创建并运行Form1窗体
            Application.Run(new Form1());
        }
    }
}