using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace dz12._04_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = searchTextBox.Text;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                resultTextBlock.Text = "Please enter a search term.";
                return;
            }

            string filePath = "sample.txt";

            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);

                int occurrences = SearchWordCount(fileContent, searchTerm);

                resultTextBlock.Text = $"Occurrences of '{searchTerm}': {occurrences}";
            }
            else
            {
                resultTextBlock.Text = "File not found.";
            }
        }

        private int SearchWordCount(string content, string word)
        {
            int count = Regex.Matches(content, @"\b" + Regex.Escape(word) + @"\b", RegexOptions.IgnoreCase).Count;
            return count;
        }
    }
}
