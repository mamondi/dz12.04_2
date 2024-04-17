using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace dz12._04_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnalyzeFileButton_Click(object sender, RoutedEventArgs e)
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
                int[] numbers = fileContent.Split(' ').Select(int.Parse).ToArray();

                int positiveCount = numbers.Count(n => n > 0);
                int negativeCount = numbers.Count(n => n < 0);
                int twoDigitCount = numbers.Count(n => n >= 10 && n <= 99);
                int fiveDigitCount = numbers.Count(n => n >= 10000 && n <= 99999);

                positiveNumbersTextBlock.Text = $"Positive Numbers Count: {positiveCount}";
                negativeNumbersTextBlock.Text = $"Negative Numbers Count: {negativeCount}";
                twoDigitNumbersTextBlock.Text = $"Two-Digit Numbers Count: {twoDigitCount}";
                fiveDigitNumbersTextBlock.Text = $"Five-Digit Numbers Count: {fiveDigitCount}";

                SaveNumbersToFile("positive_numbers.txt", numbers.Where(n => n > 0));
                SaveNumbersToFile("negative_numbers.txt", numbers.Where(n => n < 0));
                SaveNumbersToFile("two_digit_numbers.txt", numbers.Where(n => n >= 10 && n <= 99));
                SaveNumbersToFile("five_digit_numbers.txt", numbers.Where(n => n >= 10000 && n <= 99999));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
        }

        private void SaveNumbersToFile(string fileName, IEnumerable<int> numbers)
        {
            try
            {
                File.WriteAllLines(fileName, numbers.Select(n => n.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred while saving numbers to file {fileName}: {ex.Message}");
            }
        }
    }
}
