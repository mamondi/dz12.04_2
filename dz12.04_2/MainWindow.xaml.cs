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

        private void ReverseFileContentButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = filePathTextBox.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please enter a valid file path.");
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                string reversedContent = ReverseString(fileContent);

                string reversedFilePath = Path.Combine(Path.GetDirectoryName(filePath), "reversed_" + Path.GetFileName(filePath));
                File.WriteAllText(reversedFilePath, reversedContent);

                reverseFileContentStatsTextBlock.Text = $"Reversed content saved to {reversedFilePath}.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
        }

        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
