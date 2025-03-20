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
        // ���캯�������ڳ�ʼ���������
        public Form1()
        {
            InitializeComponent();
        }

        // ѡ���һ���ļ���ť�ĵ���¼�������
        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            // ����һ�����ļ��Ի���
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // �����ļ���������ֻ��ʾtxt�ļ�
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            // ��ʾ���ļ��Ի�������û�����ˡ�ȷ������ť
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ѡ����ļ�·����ʾ���ı�����
                txtFilePath1.Text = openFileDialog.FileName;
            }
        }

        // ѡ��ڶ����ļ���ť�ĵ���¼�������
        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            // ����һ�����ļ��Ի���
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // �����ļ���������ֻ��ʾtxt�ļ�
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            // ��ʾ���ļ��Ի�������û�����ˡ�ȷ������ť
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ѡ����ļ�·����ʾ���ı�����
                txtFilePath2.Text = openFileDialog.FileName;
            }
        }

        // �ϲ��ļ���ť�ĵ���¼�������
        private void btnMergeFiles_Click(object sender, EventArgs e)
        {
            // ��ȡ��һ���ļ���·��
            string filePath1 = txtFilePath1.Text;
            // ��ȡ�ڶ����ļ���·��
            string filePath2 = txtFilePath2.Text;
            // ����ļ��Ƿ�����Ҷ���txt�ļ�
            if (File.Exists(filePath1) && File.Exists(filePath2) && Path.GetExtension(filePath1).ToLower() == ".txt" && Path.GetExtension(filePath2).ToLower() == ".txt")
            {
                try
                {
                    // �����ļ��ϲ�����
                    FileMerger fileMerger = new FileMerger();
                    // ���úϲ��ļ���������ȡ�ϲ����ļ���·��
                    string mergedFilePath = fileMerger.MergeFiles(filePath1, filePath2);
                    // ����״̬��ǩ����ʾ�ļ��ϲ��ɹ���Ϣ
                    lblStatus.Text = "�ļ��ϲ��ɹ���";
                    // ���ô򿪺ϲ��ļ���ť
                    btnOpenMergedFile.Enabled = true;
                }
                catch (Exception ex)
                {
                    // ����ϲ��ļ�ʱ�����쳣������״̬��ǩ��ʾ������Ϣ
                    lblStatus.Text = "�ϲ��ļ�ʱ����: " + ex.Message;
                }
            }
            else
            {
                // ����ļ������ڻ���txt�ļ�������״̬��ǩ��ʾ��Ч�ļ���Ϣ
                lblStatus.Text = "��ѡ����Ч��txt�ļ���";
            }
        }

        // �򿪺ϲ��ļ���ť�ĵ���¼�������
        private void btnOpenMergedFile_Click(object sender, EventArgs e)
        {
            // ��ȡ��ǰִ�г����Ŀ¼
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            // ������źϲ��ļ���DataĿ¼·��
            string dataDirectory = Path.Combine(appDirectory, "Data");
            // ��ȡDataĿ¼�µ������ļ�
            string[] files = Directory.GetFiles(dataDirectory);
            // ���Ŀ¼�����ļ�
            if (files.Length > 0)
            {
                // ��ȡ�����޸ĵ��ļ�
                string latestFile = files.OrderByDescending(f => File.GetLastWriteTime(f)).First();
                // ����ļ��Ƿ����
                if (File.Exists(latestFile))
                {
                    try
                    {
                        // ʹ��ϵͳĬ�ϳ���򿪺ϲ�����ļ�
                        Process.Start(new ProcessStartInfo(latestFile) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        // ������ļ�ʱ�����쳣������״̬��ǩ��ʾ������Ϣ
                        lblStatus.Text = "���ļ�ʱ����: " + ex.Message;
                        // ����ϸ�Ĵ�����Ϣ���������̨
                        Console.WriteLine($"Error opening file: {ex.ToString()}");
                    }
                }
                else
                {
                    // ����ļ������ڣ�����״̬��ǩ��ʾ�ļ���������Ϣ
                    lblStatus.Text = "�ļ�������: " + latestFile;
                }
            }
            else
            {
                // ���Ŀ¼��û���ļ�������״̬��ǩ��ʾδ�ҵ��ϲ����ļ���Ϣ
                lblStatus.Text = "δ�ҵ��ϲ�����ļ���";
            }
        }

        // ״̬��ǩ�ĵ���¼���������Ŀǰδ��Ӿ����߼�
        private void lblStatus_Click(object sender, EventArgs e)
        {
            // ������������ӵ�� lblStatus ʱ���߼�
        }
    }
}