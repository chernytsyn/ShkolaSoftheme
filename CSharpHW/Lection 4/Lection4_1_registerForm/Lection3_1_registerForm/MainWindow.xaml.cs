using System;
using System.Windows;
using System.Windows.Controls;


namespace Lection3_1_registerForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            userBirthdate.Text = "Date must be in dd/mm/yy format ";
        }

        public void BirthDate_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= BirthDate_GotFocus;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            //Name checker
            if (NamesChecker(userName))
            {
                result += $"✓ - UserName is correct = {userName.Text}; \n";
            }
            else
            {
                result += $"✘ - UserName is incorrect = {userName.Text}; \n";
            }

            //Surname checker
            if (NamesChecker(userSurname))
            {
                result += $"✓ - UserSurname is correct = {userSurname.Text}; \n";
            }
            else
            {
                result += $"✘ - UserSurname is incorrect = {userSurname.Text}; \n";
            }

            //Birthdate checker
            if (BirthDateChecker(userBirthdate))
            {
                result += $"✓ - BirthDate is correct = {userBirthdate.Text}; \n";
            }
            else
            {
                result += $"✘ - BirthDate is incorrect = {userBirthdate.Text}; \n";
            }

            //Gender Checker
            if (GenderChecker(userGender))
            {
                result += $"✓ - Gender is correct = {userGender.Text}; \n";
            }
            else
            {
                result += $"✘ - Gender is incorrect = {userGender.Text}; \n";
            }

            //Email checker
            if (EmailChecker(userEmail))
            {
                result += $"✓ - Email is correct = {userEmail.Text}; \n";
            }
            else
            {
                result += $"✘ - Email is incorrect = {userEmail.Text}; \n";
            }

            //Phone checker
            if (PhoneChecker(userPhone))
            {
                result += $"✓ - Phone is correct = {userPhone.Text}; \n";
            }
            else
            {
                result += $"✘ - Phone is incorrect = {userPhone.Text}; \n";
            }

            //Info checker
            if (InfoChecker(userInfo))
            {
                result += $"✓ - Info is correct = {userInfo.Text}; \n";
            }
            else
            {
                result += $"✘ - Info is incorrect = {userInfo.Text}; \n";
            }

            MessageBox.Show(result);
        }

        private bool NamesChecker(TextBox name)
        {
            if (IsLetterOnly(name.Text))
            {
                if (name.Text.Length > 255)
                {
                    MessageBox.Show($"{name.Name} is too long, must be 255 symbols");
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"{name.Name} got digits. Validation incorrect!");
                return false;
            }
            return true;
        }

        private bool BirthDateChecker(TextBox birthdate)
        {
            string[] dateParts = birthdate.Text.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var s_day = dateParts[0];
                var s_month = dateParts[1];
                var s_year = dateParts[2];

                var i_day = Convert.ToInt32(s_day);
                var i_month = Convert.ToInt32(s_month);
                var i_year = Convert.ToInt32(s_year);

                if (i_day > 31 || i_day < 1)
                {
                    return false;
                }

                if (i_month > 12 || i_month < 1)
                {
                    return false;
                }

                else if (i_year > DateTime.Today.Year || i_year < 1900)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool GenderChecker(TextBox gender)
        {
            if (gender.Text.ToLower() == "male" || gender.Text.ToLower() == "female")
            {
                return true;
            }
            else return false;
        }

        private bool EmailChecker(TextBox email)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(email.Text, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"))
            {
                MessageBox.Show("Email incorrect validation");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool PhoneChecker(TextBox phone)
        {
            if (IsDigitOnly(phone.Text))
            {
                if (phone.Text.Length > 12)
                {
                    MessageBox.Show($"{phone.Name} is too long, must be 12 symbols");
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"{phone.Name} got letters. Validation incorrect!");
                return false;
            }
            return true;
        }

        private bool InfoChecker(TextBox info)
        {
            if (info.Text.Length > 2000)
            {
                MessageBox.Show("Info must be smaller than 2000 symbols");
                return false;
            }
            else return true;
        }


        private bool IsDigitOnly(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private bool IsLetterOnly(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

    }
}
