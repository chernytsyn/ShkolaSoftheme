using System.Windows;
using System.Windows.Controls;


namespace Lection2_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            values.Text = "Please select a numeric primitive type";
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedType.Text)
            {
                case "byte":
                {
                    ShowByte();
                    break;
                }
                case "int":
                {
                    ShowInt();
                    break;
                }
                case "long":
                {
                    ShowLong();
                    break;
                }
                case "double":
                {
                    ShowDouble();
                    break;

                }
                case "float":
                {
                    ShowFloat();
                    break;
                }
                case "decimal":
                {
                    ShowDecimal();
                    break;
                }
                default:
                {
                    MessageBox.Show("Please, select numeric type");
                    break;
                }
            }
        }

        private void ShowByte()
        {
            values.Text =
                $"MAX Value = {byte.MaxValue} \nMIN Value = {byte.MinValue} \nDEFAULT Value = {default(byte)}";
        }

        private void ShowInt()
        {
            if (positive.IsChecked.Equals(true))
            {
                values.Text =
                    $"MAX Value = {uint.MaxValue} \nMIN Value = {uint.MinValue} \nDEFAULT Value = {default(uint)}";
            }
            else
            {
                values.Text =
                    $"MAX Value = {int.MaxValue} \nMIN Value = {int.MinValue} \nDEFAULT Value = {default(int)}";
            }

        }

        private void ShowLong()
        {
            if (positive.IsChecked.Equals(true))
            {
                values.Text =
                    $"MAX Value = {ulong.MaxValue} \nMIN Value = {ulong.MinValue} \nDEFAULT Value = {default(ulong)}";
            }
            else
            {
                values.Text =
                    $"MAX Value = {long.MaxValue} \nMIN Value = {long.MinValue} \nDEFAULT Value = {default(long)}";
            }
        }

        private void ShowDouble()
        {
            values.Text =
                $"MAX Value = {double.MaxValue} \nMIN Value = {double.MinValue} \nDEFAULT Value = {default(double)}";
        }

        private void ShowFloat()
        {
            values.Text =
                $"MAX Value = {float.MaxValue} \nMIN Value = {float.MinValue} \nDEFAULT Value = {default(float)}";
        }

        private void ShowDecimal()
        {
            values.Text =
                $"MAX Value = {decimal.MaxValue} \nMIN Value = {decimal.MinValue} \nDEFAULT Value = {default(decimal)}";
        }

        private void selectedType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // makes unavaibale to check checkbox for some values (not uint,ulong)
            if (selectedType.SelectedIndex > 2 || selectedType.SelectedIndex < 1)
            {
                positive.IsChecked = false;
                positive.IsEnabled = false;
            }
            else
            {
                positive.IsEnabled = true;
            }
        } 
    }
}
