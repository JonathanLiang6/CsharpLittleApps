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
            urlToolTip.SetToolTip(txtUrl, "输入URL地址(http://或https://)或选择本地HTML文件");
            urlToolTip.SetToolTip(btnBrowse, "选择本地HTML文件");

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("复制所有结果", null, (s, e) => CopyAllResults());
            contextMenu.Items.Add("清除结果", null, (s, e) => txtResult.Clear());
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add("导出结果...", null, (s, e) => ExportResults());
            txtResult.ContextMenuStrip = contextMenu;

            btnAnalyze.Enabled = true;
            txtResult.ReadOnly = true;
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (isAnalyzing)
            {
                MessageBox.Show("正在分析中，请稍候...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("请输入URL地址或选择本地文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("请输入有效的URL地址或选择本地HTML文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await AnalyzeContent(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"分析过程中发生错误\n{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnAnalyze.Text = enabled ? "分析" : "分析中...";
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
            AppendResult("开始分析内容...\r\n");

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

            AppendResult($"分析完成！共找到 {phones.Count} 个手机号码和 {emails.Count} 个邮箱地址。\r\n");

            if (phones.Count > 0)
            {
                AppendResult("\r\n【手机号码】");
                foreach (var phone in phones)
                {
                    AppendResult($"\r\n{phone}");
                }
            }

            if (emails.Count > 0)
            {
                AppendResult("\r\n\r\n【邮箱地址】");
                foreach (var email in emails)
                {
                    AppendResult($"\r\n{email}");
                }
            }

            if (phones.Count == 0 && emails.Count == 0)
            {
                AppendResult("\r\n未找到任何联系方式。");
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
                MessageBox.Show("内容已复制到剪贴板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportResults()
        {
            if (string.IsNullOrWhiteSpace(txtResult.Text))
            {
                MessageBox.Show("没有可导出的结果！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*",
                DefaultExt = "txt",
                FileName = "分析结果_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveDialog.FileName, txtResult.Text);
                    MessageBox.Show("结果已成功导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "HTML文件(*.html;*.htm)|*.html;*.htm|所有文件(*.*)|*.*",
                Title = "选择HTML文件"
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