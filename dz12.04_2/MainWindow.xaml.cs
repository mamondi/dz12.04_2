using System;
using System.IO;
using System.Windows;

namespace dz12._04_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchAndReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = filePathTextBox.Text;
            string searchWord = searchTextBox.Text;
            string replaceWord = replaceTextBox.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please enter a valid file path.");
                return;
            }

            if (string.IsNullOrWhiteSpace(searchWord))
            {
                MessageBox.Show("Please enter a word to search.");
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                int count = ReplaceOccurrences(ref fileContent, searchWord, replaceWord);
                File.WriteAllText(filePath, fileContent);

                searchReplaceStatsTextBlock.Text = $"Replaced {count} occurrences of '{searchWord}' with '{replaceWord}' in the file.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
        }

        private int ReplaceOccurrences(ref string content, string searchWord, string replaceWord)
        {
            int count = 0;
            int index = content.IndexOf(searchWord, StringComparison.OrdinalIgnoreCase);

            while (index != -1)
            {
                content = content.Remove(index, searchWord.Length).Insert(index, replaceWord);
                index = content.IndexOf(searchWord, index + replaceWord.Length, StringComparison.OrdinalIgnoreCase);
                count++;
            }

            return count;
        }
    }
}
