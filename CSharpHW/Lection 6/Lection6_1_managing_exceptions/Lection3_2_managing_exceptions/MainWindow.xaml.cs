using System;
using System.Windows;
using System.Windows.Controls;


namespace Lection3_2_managing_exceptions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int RandomValue { get; set; }
        private static int attemptsRemain = 3;

        Random random;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            RandomValue = random.Next(1, 11);
        }

        private void StartAgain()
        {
            attemptsRemain = 3;
            RandomValue = random.Next(1, 11);

            hintButton.IsEnabled = false;
            userAnswer.Text = "";
            hintTextBlock.Text = "";

            MessageBox.Show("The game started again. Good luck!");
        }

        private bool ValidateAnswer(TextBox userAnswer)
        {
            if (IsDigit(userAnswer))
            {
                var i_answer = Convert.ToInt32(userAnswer.Text);
                if (i_answer > 10 || i_answer < 1)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (i_answer == RandomValue)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsDigit(TextBox userAnswer)
        {
            foreach (char c in userAnswer.Text)
            {
                if (!char.IsDigit(c))
                {
                    throw new FormatException();
                }
            }
            return true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateAnswer(userAnswer))
                {
                    MessageBox.Show("Yes! That's the correct answer!");
                    StartAgain();
                }
                else
                {
                    attemptsRemain--;
                    MessageBox.Show($"The answer is incorrect. \n You've got {attemptsRemain} more attempts to try");
                    if (attemptsRemain < 2)
                    {
                        hintButton.IsEnabled = true;
                    }
                    if (attemptsRemain == 0)
                    {
                        MessageBox.Show("Oops, you lose. Have a better luck next time");
                        StartAgain();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format of answer. Please enter digits");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Invalid digit, the digit must be in between of 1 and 10 range");
            }
        }


        private void hintButton_Click(object sender, RoutedEventArgs e)
        {
            if (RandomValue > 5)
            {
                hintTextBlock.Text = "The answer is in between 6 and 10";
            }
            else
            {
                hintTextBlock.Text = "The answer is in between 1 and 5";
            }
        }
    }
}
