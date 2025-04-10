using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LittleSearcher
{
    public class SearchHistory
    {
        private const string HistoryFilePath = "search_history.json";
        private const int MaxHistoryItems = 50;
        private List<string> _history;

        public SearchHistory()
        {
            _history = new List<string>();
            LoadHistory();
        }

        public void AddSearchTerm(string term)
        {
            if (string.IsNullOrWhiteSpace(term)) return;

            // Remove if already exists
            _history.Remove(term);
            
            // Add to beginning of list
            _history.Insert(0, term);

            // Trim to max items
            if (_history.Count > MaxHistoryItems)
            {
                _history = _history.Take(MaxHistoryItems).ToList();
            }

            SaveHistory();
        }

        public List<string> GetHistory()
        {
            return new List<string>(_history);
        }

        public void ClearHistory()
        {
            _history.Clear();
            SaveHistory();
        }

        private void LoadHistory()
        {
            try
            {
                if (File.Exists(HistoryFilePath))
                {
                    string json = File.ReadAllText(HistoryFilePath);
                    _history = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                }
            }
            catch (Exception)
            {
                _history = new List<string>();
            }
        }

        private void SaveHistory()
        {
            try
            {
                string json = JsonSerializer.Serialize(_history);
                File.WriteAllText(HistoryFilePath, json);
            }
            catch (Exception)
            {
                // Handle save error silently
            }
        }
    }
} 