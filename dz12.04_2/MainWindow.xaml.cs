using System;
using System.IO;
using System.Linq;
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

                int sentenceCount = CountSentences(fileContent);
                int uppercaseCount = CountUppercaseLetters(fileContent);
                int lowercaseCount = CountLowercaseLetters(fileContent);
                int vowelCount = CountVowels(fileContent);
                int consonantCount = CountConsonants(fileContent);
                int digitCount = CountDigits(fileContent);

                DisplayStats(sentenceCount, uppercaseCount, lowercaseCount, vowelCount, consonantCount, digitCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
        }

        private int CountSentences(string text)
        {
            return text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private int CountUppercaseLetters(string text)
        {
            return text.Count(char.IsUpper);
        }

        private int CountLowercaseLetters(string text)
        {
            return text.Count(char.IsLower);
        }

        private int CountVowels(string text)
        {
            return Regex.Matches(text, @"[aeiouAEIOU]").Count;
        }

        private int CountConsonants(string text)
        {
            return Regex.Matches(text, @"[bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]").Count;
        }

        private int CountDigits(string text)
        {
            // Count digits using regular expression
            return Regex.Matches(text, @"\d").Count;
        }

        private void DisplayStats(int sentenceCount, int uppercaseCount, int lowercaseCount, int vowelCount, int consonantCount, int digitCount)
        {
            sentenceCountTextBlock.Text = $"Number of sentences: {sentenceCount}";
            uppercaseCountTextBlock.Text = $"Uppercase letters count: {uppercaseCount}";
            lowercaseCountTextBlock.Text = $"Lowercase letters count: {lowercaseCount}";
            vowelCountTextBlock.Text = $"Vowel letters count: {vowelCount}";
            consonantCountTextBlock.Text = $"Consonant letters count: {consonantCount}";
            digitCountTextBlock.Text = $"Digit count: {digitCount}";
        }
    }
}
