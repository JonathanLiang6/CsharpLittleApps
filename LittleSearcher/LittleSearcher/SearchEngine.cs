using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Web;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace LittleSearcher
{
    public class SearchEngine
    {
        private readonly HttpClient _httpClient;

        public SearchEngine()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            
            // 注册编码提供程序
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public async Task<(string text, List<(int start, int length)> highlights)> SearchBaiduAsync(string keyword, int length)
        {
            try
            {
                var encodedKeyword = HttpUtility.UrlEncode(keyword, Encoding.UTF8);
                var url = $"https://www.baidu.com/s?wd={encodedKeyword}&rn=50";
                
                var response = await _httpClient.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(response);

                var results = new List<string>();
                
                // 使用更精确的选择器来获取搜索结果
                var contentNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'c-container')][@id]");

                if (contentNodes != null)
                {
                    foreach (var node in contentNodes)
                    {
                        // 标题选择器
                        var titleNode = node.SelectSingleNode(".//h3[contains(@class, 't')]//a");
                        
                        if (titleNode != null)
                        {
                            var titleText = HttpUtility.HtmlDecode(titleNode.InnerText).Trim();
                            titleText = Regex.Replace(titleText, @"\s+", " ");
                            
                            if (!string.IsNullOrWhiteSpace(titleText))
                            {
                                results.Add($"标题: {titleText}");
                            }

                            // 首先尝试获取主要摘要
                            var abstractNode = node.SelectSingleNode(".//div[contains(@class, 'c-abstract')] | .//div[contains(@class, 'content-abstract')]");
                            
                            if (abstractNode == null)
                            {
                                // 如果没有找到主要摘要，尝试其他位置
                                abstractNode = node.SelectSingleNode(
                                    ".//div[contains(@class, 'c-row')]//p | " +
                                    ".//div[contains(@class, 'c-span-last')]//p | " +
                                    ".//div[contains(@class, 'c-row')]//div[contains(@class, 'c-abstract')] | " +
                                    ".//div[contains(@class, 'content-right_8Zs40')]//div[contains(@class, 'content-abstract')]"
                                );
                            }

                            if (abstractNode != null)
                            {
                                var abstractText = abstractNode.InnerText;
                                // 清理摘要文本
                                abstractText = HttpUtility.HtmlDecode(abstractText).Trim();
                                abstractText = Regex.Replace(abstractText, @"\s+", " ");
                                abstractText = Regex.Replace(abstractText, @"[\r\n]+", " ");
                                
                                // 移除常见的无用文本
                                abstractText = Regex.Replace(abstractText, @"(举报|投诉|查看更多|百度快照|百度翻译|百度图片|百度视频|百度地图|百度经验).*", "");
                                
                                if (!string.IsNullOrWhiteSpace(abstractText))
                                {
                                    results.Add($"摘要: {abstractText}\n");
                                }
                            }
                        }
                    }
                }

                // 如果没有找到任何结果，返回提示信息
                string resultText = !results.Any() ? "未找到相关搜索结果" : string.Join("\n", results.Take(length));

                // 查找所有需要高亮的位置
                var highlights = FindHighlightPositions(resultText, keyword);

                return (resultText, highlights);
            }
            catch (Exception ex)
            {
                return ($"百度搜索出错: {ex.Message}", new List<(int, int)>());
            }
        }

        public async Task<(string text, List<(int start, int length)> highlights)> SearchBingAsync(string keyword, int length)
        {
            try
            {
                var encodedKeyword = HttpUtility.UrlEncode(keyword, Encoding.UTF8);
                var url = $"https://cn.bing.com/search?q={encodedKeyword}&ensearch=0";
                
                var response = await _httpClient.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(response);

                var results = new List<string>();
                var contentNodes = doc.DocumentNode.SelectNodes("//li[@class='b_algo']");

                if (contentNodes != null)
                {
                    foreach (var node in contentNodes)
                    {
                        var titleNode = node.SelectSingleNode(".//h2//a");
                        var abstractNode = node.SelectSingleNode(".//div[@class='b_caption']//p | .//p[@class='b_paractl']");

                        if (titleNode != null)
                        {
                            var titleText = HttpUtility.HtmlDecode(titleNode.InnerText).Trim();
                            if (!string.IsNullOrWhiteSpace(titleText))
                            {
                                results.Add($"标题: {titleText}");
                            }

                            if (abstractNode != null)
                            {
                                var abstractText = HttpUtility.HtmlDecode(abstractNode.InnerText).Trim();
                                abstractText = Regex.Replace(abstractText, @"\s+", " ");
                                
                                if (!string.IsNullOrWhiteSpace(abstractText))
                                {
                                    results.Add($"摘要: {abstractText}\n");
                                }
                            }
                            else
                            {
                                // 尝试查找其他可能包含摘要的元素
                                var alternativeAbstractNode = node.SelectSingleNode(".//div[@class='b_caption']");
                                if (alternativeAbstractNode != null)
                                {
                                    var abstractText = alternativeAbstractNode.InnerText;
                                    abstractText = HttpUtility.HtmlDecode(abstractText).Trim();
                                    abstractText = Regex.Replace(abstractText, @"\s+", " ");
                                    
                                    if (!string.IsNullOrWhiteSpace(abstractText))
                                    {
                                        results.Add($"摘要: {abstractText}\n");
                                    }
                                }
                            }
                        }
                    }
                }

                string resultText = !results.Any() ? "未找到相关搜索结果" : string.Join("\n", results.Take(length));
                var highlights = FindHighlightPositions(resultText, keyword);

                return (resultText, highlights);
            }
            catch (Exception ex)
            {
                return ($"必应搜索出错: {ex.Message}", new List<(int, int)>());
            }
        }

        private List<(int start, int length)> FindHighlightPositions(string text, string keyword)
        {
            var positions = new List<(int start, int length)>();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keyword))
                return positions;

            keyword = keyword.Trim();
            int currentIndex = 0;

            while (true)
            {
                int index = text.IndexOf(keyword, currentIndex, StringComparison.OrdinalIgnoreCase);
                if (index == -1)
                    break;

                positions.Add((index, keyword.Length));
                currentIndex = index + keyword.Length;
            }

            return positions;
        }
    }
} 