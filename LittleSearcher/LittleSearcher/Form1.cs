using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LittleSearcher
{
    public partial class Form1 : Form
    {
        private readonly SearchEngine _searchEngine;
        private readonly SearchHistory _searchHistory;
        private int _resultLength = 200;
        private readonly Color _highlightColor = Color.Yellow;

        public Form1()
        {
            InitializeComponent();
            _searchEngine = new SearchEngine();
            _searchHistory = new SearchHistory();
            SetupEventHandlers();
            LoadSearchHistory();
        }

        private void SetupEventHandlers()
        {
            // 搜索按钮点击事件
            searchButton.Click += async (s, e) => await PerformSearch();
            
            // 清除历史按钮点击事件
            clearHistoryButton.Click += (s, e) => 
            {
                _searchHistory.ClearHistory();
                LoadSearchHistory();
            };
            
            // 历史记录选择事件
            historyComboBox.SelectedIndexChanged += async (s, e) => 
            {
                if (historyComboBox.SelectedItem != null)
                {
                    searchTextBox.Text = historyComboBox.SelectedItem.ToString();
                    await PerformSearch();
                }
            };

            // 搜索框回车事件
            searchTextBox.KeyPress += async (s, e) => 
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    await PerformSearch();
                }
            };

            // 结果长度改变事件
            lengthNumeric.ValueChanged += (s, e) => 
            {
                if (searchTextBox.Text.Length > 0)
                {
                    _ = PerformSearch();
                }
            };
        }

        private async Task PerformSearch()
        {
            string keyword = searchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入搜索关键字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                statusLabel.Text = "正在搜索...";
                searchButton.Enabled = false;
                baiduTextBox.Clear();
                bingTextBox.Clear();

                var baiduTask = _searchEngine.SearchBaiduAsync(keyword, (int)lengthNumeric.Value);
                var bingTask = _searchEngine.SearchBingAsync(keyword, (int)lengthNumeric.Value);

                await Task.WhenAll(baiduTask, bingTask);

                // 显示百度搜索结果
                var (baiduText, baiduHighlights) = baiduTask.Result;
                DisplayTextWithHighlights(baiduTextBox, baiduText, baiduHighlights);

                // 显示必应搜索结果
                var (bingText, bingHighlights) = bingTask.Result;
                DisplayTextWithHighlights(bingTextBox, bingText, bingHighlights);

                // 添加到历史记录
                _searchHistory.AddSearchTerm(keyword);
                LoadSearchHistory();

                statusLabel.Text = "搜索完成";
            }
            catch (Exception ex)
            {
                statusLabel.Text = "搜索出错";
                MessageBox.Show($"搜索过程中发生错误: {ex.Message}", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                searchButton.Enabled = true;
            }
        }

        private void DisplayTextWithHighlights(RichTextBox rtb, string text, List<(int start, int length)> highlights)
        {
            rtb.Clear();
            rtb.SuspendLayout();

            // 添加文本
            rtb.Text = text;

            // 应用高亮
            foreach (var (start, length) in highlights)
            {
                rtb.Select(start, length);
                rtb.SelectionBackColor = _highlightColor;
            }

            // 清除选择
            rtb.SelectionLength = 0;
            rtb.SelectionBackColor = rtb.BackColor;

            rtb.ResumeLayout();
        }

        private void LoadSearchHistory()
        {
            historyComboBox.Items.Clear();
            historyComboBox.Items.AddRange(_searchHistory.GetHistory().ToArray());
        }
    }
}
