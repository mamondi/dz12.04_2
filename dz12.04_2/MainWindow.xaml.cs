using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Використав LinQ, до речі

namespace dz12._04_2
{
    public partial class MainWindow : Window
    {
        public tenThousandRandomNumbers Numbers { get; set; } = new tenThousandRandomNumbers();
        public int EvenNumbersCount { get; set; }
        public int OddNumbersCount { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateNumbersButton_Click(object sender, RoutedEventArgs e)
        {
            Numbers = new tenThousandRandomNumbers();

            EvenNumbersCount = Numbers.numbers.Count(number => number % 2 == 0);
            OddNumbersCount = Numbers.numbers.Count(number => number % 2 != 0);

            Numbers.saveEvenNumbers();
            saveOddNumbers();

            EvenNumbersCountTextBlock.Text = EvenNumbersCount.ToString();
            OddNumbersCountTextBlock.Text = OddNumbersCount.ToString();
        }


        private void saveOddNumbers()
        {
            using (StreamWriter file = new StreamWriter("oddNumbers.txt"))
            {
                foreach (int number in Numbers.numbers)
                {
                    if (number % 2 != 0)
                    {
                        file.WriteLine(number);
                    }
                }
            }
        }
    }

    public class tenThousandRandomNumbers
    {
        public List<int> numbers = new List<int>();

        public tenThousandRandomNumbers()
        {
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                numbers.Add(random.Next(0, 10000));
            }
        }

        public int this[int index]
        {
            get
            {
                return numbers[index];
            }
            set
            {
                numbers[index] = value;
            }
        }

        public void saveEvenNumbers()
        {
            using (StreamWriter file = new StreamWriter("evenNumbers.txt"))
            {
                foreach (int number in numbers)
                {
                    if (number % 2 == 0)
                    {
                        file.WriteLine(number);
                    }
                }
            }
        }
    }
}