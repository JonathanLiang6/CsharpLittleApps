using System;
using System.Windows.Forms;

namespace TextFileMerger
{
    // ��������࣬���������������
    static class Program
    {
        // Ӧ�ó��������ڵ�
        [STAThread]
        static void Main()
        {
            // ����Ӧ�ó�����Ӿ���ʽ��ʹ����в���ϵͳ�����
            Application.EnableVisualStyles();
            // �����ı�����Ĭ��ֵ��ȷ���ı���ʾһ��
            Application.SetCompatibleTextRenderingDefault(false);
            // ����������Form1����
            Application.Run(new Form1());
        }
    }
}