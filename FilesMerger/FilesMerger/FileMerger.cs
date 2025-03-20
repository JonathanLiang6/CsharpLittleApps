using System;
using System.IO;
using System.Reflection;

namespace TextFileMerger
{
    // 文件合并类
    public class FileMerger
    {
        // 合并两个文件的方法
        // filePath1: 第一个文件的路径
        // filePath2: 第二个文件的路径
        // 返回值: 合并后文件的路径
        public string MergeFiles(string filePath1, string filePath2)
        {
            try
            {
                // 检查文件是否存在，如果有任何一个文件不存在，则抛出异常
                if (!File.Exists(filePath1) || !File.Exists(filePath2))
                {
                    throw new FileNotFoundException("选择的文件不存在，请选择有效的文件。");
                }
                // 读取第一个文件的内容
                string content1 = File.ReadAllText(filePath1);
                // 读取第二个文件的内容
                string content2 = File.ReadAllText(filePath2);
                // 将两个文件的内容合并，中间用换行符分隔
                string mergedContent = content1 + Environment.NewLine + content2;
                // 获取当前执行程序的目录
                string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
                // 构建存放合并文件的Data目录路径
                string dataDirectory = Path.Combine(appDirectory, "Data");
                // 如果Data目录不存在，则创建该目录
                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }
                // 获取当前时间戳，格式为yyyyMMddHHmmss
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                // 构建合并后文件的文件名
                string outputFileName = $"merged_{timestamp}.txt";
                // 构建合并后文件的完整路径
                string outputFilePath = Path.Combine(dataDirectory, outputFileName);
                // 将合并后的内容写入到新文件中
                File.WriteAllText(outputFilePath, mergedContent);
                // 返回合并后文件的路径
                return outputFilePath;
            }
            catch (Exception ex)
            {
                // 如果在文件合并或保存过程中发生错误，抛出包含错误信息的异常
                throw new Exception($"文件合并或保存时发生错误: {ex.Message}");
            }
        }
    }
}