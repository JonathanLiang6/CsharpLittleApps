using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

namespace TextFileMerger
{
    public partial class Form1 : Form
    {
        // 构造函数，用于初始化窗体组件
        public Form1()
        {
            InitializeComponent();
        }

        // 选择第一个文件按钮的点击事件处理方法
        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            // 创建一个打开文件对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // 设置文件过滤器，只显示txt文件
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            // 显示打开文件对话框，如果用户点击了“确定”按钮
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 将选择的文件路径显示在文本框中
                txtFilePath1.Text = openFileDialog.FileName;
            }
        }

        // 选择第二个文件按钮的点击事件处理方法
        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            // 创建一个打开文件对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // 设置文件过滤器，只显示txt文件
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            // 显示打开文件对话框，如果用户点击了“确定”按钮
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 将选择的文件路径显示在文本框中
                txtFilePath2.Text = openFileDialog.FileName;
            }
        }

        // 合并文件按钮的点击事件处理方法
        private void btnMergeFiles_Click(object sender, EventArgs e)
        {
            // 获取第一个文件的路径
            string filePath1 = txtFilePath1.Text;
            // 获取第二个文件的路径
            string filePath2 = txtFilePath2.Text;
            // 检查文件是否存在且都是txt文件
            if (File.Exists(filePath1) && File.Exists(filePath2) && Path.GetExtension(filePath1).ToLower() == ".txt" && Path.GetExtension(filePath2).ToLower() == ".txt")
            {
                try
                {
                    // 创建文件合并对象
                    FileMerger fileMerger = new FileMerger();
                    // 调用合并文件方法，获取合并后文件的路径
                    string mergedFilePath = fileMerger.MergeFiles(filePath1, filePath2);
                    // 更新状态标签，显示文件合并成功信息
                    lblStatus.Text = "文件合并成功！";
                    // 启用打开合并文件按钮
                    btnOpenMergedFile.Enabled = true;
                }
                catch (Exception ex)
                {
                    // 如果合并文件时发生异常，更新状态标签显示错误信息
                    lblStatus.Text = "合并文件时出错: " + ex.Message;
                }
            }
            else
            {
                // 如果文件不存在或不是txt文件，更新状态标签显示无效文件信息
                lblStatus.Text = "请选择有效的txt文件！";
            }
        }

        // 打开合并文件按钮的点击事件处理方法
        private void btnOpenMergedFile_Click(object sender, EventArgs e)
        {
            // 获取当前执行程序的目录
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            // 构建存放合并文件的Data目录路径
            string dataDirectory = Path.Combine(appDirectory, "Data");
            // 获取Data目录下的所有文件
            string[] files = Directory.GetFiles(dataDirectory);
            // 如果目录中有文件
            if (files.Length > 0)
            {
                // 获取最新修改的文件
                string latestFile = files.OrderByDescending(f => File.GetLastWriteTime(f)).First();
                // 检查文件是否存在
                if (File.Exists(latestFile))
                {
                    try
                    {
                        // 使用系统默认程序打开合并后的文件
                        Process.Start(new ProcessStartInfo(latestFile) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        // 如果打开文件时发生异常，更新状态标签显示错误信息
                        lblStatus.Text = "打开文件时出错: " + ex.Message;
                        // 将详细的错误信息输出到控制台
                        Console.WriteLine($"Error opening file: {ex.ToString()}");
                    }
                }
                else
                {
                    // 如果文件不存在，更新状态标签显示文件不存在信息
                    lblStatus.Text = "文件不存在: " + latestFile;
                }
            }
            else
            {
                // 如果目录中没有文件，更新状态标签显示未找到合并后文件信息
                lblStatus.Text = "未找到合并后的文件！";
            }
        }

        // 状态标签的点击事件处理方法，目前未添加具体逻辑
        private void lblStatus_Click(object sender, EventArgs e)
        {
            // 可以在这里添加点击 lblStatus 时的逻辑
        }
    }
}