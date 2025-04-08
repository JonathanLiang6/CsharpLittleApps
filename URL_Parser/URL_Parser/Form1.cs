using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace WebContentAnalyzer
{
    public partial class Form1 : Form
    {
        private readonly string phonePattern = @"(?<!\d)(1[3-9]\d{9})(?!\d)";
        private readonly string emailPattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b(?![^<]*>)";
        private readonly HttpClient httpClient;
        private bool isAnalyzing = false;

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
            InitializeUI();
        }

        private void InitializeUI()
        {
            var urlToolTip = new System.Windows.Forms.ToolTip();
            urlToolTip.SetToolTip(txtUrl, "����URL��ַ(http://��https://)��ѡ�񱾵�HTML�ļ�");
            urlToolTip.SetToolTip(btnBrowse, "ѡ�񱾵�HTML�ļ�");

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("�������н��", null, (s, e) => CopyAllResults());
            contextMenu.Items.Add("������", null, (s, e) => txtResult.Clear());
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add("�������...", null, (s, e) => ExportResults());
            txtResult.ContextMenuStrip = contextMenu;

            btnAnalyze.Enabled = true;
            txtResult.ReadOnly = true;
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (isAnalyzing)
            {
                MessageBox.Show("���ڷ����У����Ժ�...", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("������URL��ַ��ѡ�񱾵��ļ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                isAnalyzing = true;
                UpdateUIState(false);
                txtResult.Clear();

                string content;
                if (IsLocalFile(txtUrl.Text))
                {
                    content = await File.ReadAllTextAsync(txtUrl.Text);
                }
                else if (IsValidUrl(txtUrl.Text))
                {
                    content = await DownloadContentAsync(txtUrl.Text);
                }
                else
                {
                    MessageBox.Show("��������Ч��URL��ַ��ѡ�񱾵�HTML�ļ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await AnalyzeContent(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���������з�������\n{ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isAnalyzing = false;
                UpdateUIState(true);
            }
        }

        private void UpdateUIState(bool enabled)
        {
            btnAnalyze.Enabled = enabled;
            btnBrowse.Enabled = enabled;
            txtUrl.Enabled = enabled;
            btnAnalyze.Text = enabled ? "����" : "������...";
            progressBar.Visible = !enabled;
        }

        private bool IsLocalFile(string path)
        {
            return File.Exists(path) && path.EndsWith(".html", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsValidUrl(string url)
        {
            return !string.IsNullOrWhiteSpace(url) &&
                   (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    url.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
        }

        private async Task<string> DownloadContentAsync(string url)
        {
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private async Task AnalyzeContent(string content)
        {
            AppendResult("��ʼ��������...\r\n");

            var phones = new HashSet<string>();
            var emails = new HashSet<string>();

            await Task.Run(() =>
            {
                foreach (Match match in Regex.Matches(content, phonePattern))
                {
                    phones.Add(match.Value);
                }

                foreach (Match match in Regex.Matches(content, emailPattern))
                {
                    emails.Add(match.Value);
                }
            });

            AppendResult($"������ɣ����ҵ� {phones.Count} ���ֻ������ {emails.Count} �������ַ��\r\n");

            if (phones.Count > 0)
            {
                AppendResult("\r\n���ֻ����롿");
                foreach (var phone in phones)
                {
                    AppendResult($"\r\n{phone}");
                }
            }

            if (emails.Count > 0)
            {
                AppendResult("\r\n\r\n�������ַ��");
                foreach (var email in emails)
                {
                    AppendResult($"\r\n{email}");
                }
            }

            if (phones.Count == 0 && emails.Count == 0)
            {
                AppendResult("\r\nδ�ҵ��κ���ϵ��ʽ��");
            }
        }

        private void AppendResult(string text)
        {
            if (txtResult.InvokeRequired)
            {
                txtResult.Invoke(new Action(() => txtResult.AppendText(text)));
            }
            else
            {
                txtResult.AppendText(text);
            }
        }

        private void CopyAllResults()
        {
            if (!string.IsNullOrWhiteSpace(txtResult.Text))
            {
                Clipboard.SetText(txtResult.Text);
                MessageBox.Show("�����Ѹ��Ƶ������壡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportResults()
        {
            if (string.IsNullOrWhiteSpace(txtResult.Text))
            {
                MessageBox.Show("û�пɵ����Ľ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "�ı��ļ�(*.txt)|*.txt|�����ļ�(*.*)|*.*",
                DefaultExt = "txt",
                FileName = "�������_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveDialog.FileName, txtResult.Text);
                    MessageBox.Show("����ѳɹ�������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"����ʧ�ܣ�{ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "HTML�ļ�(*.html;*.htm)|*.html;*.htm|�����ļ�(*.*)|*.*",
                Title = "ѡ��HTML�ļ�"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                txtUrl.Text = openDialog.FileName;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            httpClient.Dispose();
        }
    }
}