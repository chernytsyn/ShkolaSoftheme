using System;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Lection2_3_wpf_zodiac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string S_birthday { get; private set; }
        public DateTime Birthday { get; private set; }
        public string ZodiacSign { get; private set; }



        public MainWindow()
        {
            InitializeComponent();

        }

        private void submitBirthday_Click(object sender, RoutedEventArgs e)
        {
            ValidateBirthday();
        }

        private void ValidateBirthday()
        {
            S_birthday = birthdayTextBox.Text;

            try
            {
                string[] dateParts = S_birthday.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                var s_day = dateParts[0];
                var s_month = dateParts[1];
                var s_year = dateParts[2];

                var i_day = Convert.ToInt32(s_day);
                var i_month = Convert.ToInt32(s_month);
                var i_year = Convert.ToInt32(s_year);

                Birthday = GetUserBirthDate(i_day, i_month, i_year);

                GetAge();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid birthday. Please try again dd/mm/yy");
                birthdayTextBox.Text = "";
            }
        }

        private DateTime GetUserBirthDate(int day = 0, int month = 0, int year = 0)
        {

            if (day > 31 || day < 1)
            {
                MessageBox.Show("Incorrect day,default value 1 is substituted");
                return GetUserBirthDate(1,month,year);

            }

            if (month > 12 || month < 1)
            {
                MessageBox.Show("Incorrect month,default value 1 is substituted");
                return GetUserBirthDate(day,1,year);
            }

            else if (year > 2150 || year < 1940)
            {
                MessageBox.Show("Incorrect year,default value 2000 is substituted");
                return GetUserBirthDate(day,month,2000);
            }


            DateTime date = new DateTime(year, month, day);
            return date;
        }

        private string GetZodiacSign(DateTime birthday)
        {
            var month = birthday.Month;
            var day = birthday.Day;
            switch (month)
            {
                case 1:
                    {
                        if (day < 20) return "Capricorn"; else return "Aquarius";
                    }
                case 2:
                    {
                        if (day < 19) return "Aquarius"; else return "Pisces";
                    }
                case 3:
                    {
                        if (day < 21) return "Pisces"; else return "Aries";
                    }
                case 4:
                    {
                        if (day < 21) return "Aries"; else return "Taurus ";
                    }
                case 5:
                    {
                        if (day < 21) return "Taurus "; else return "Gemini";
                    }
                case 6:
                    {
                        if (day < 21) return "Gemini"; else return "Cancer";
                    }
                case 7:
                    {
                        if (day < 23) return "Cancer"; else return "Leo";
                    }
                case 8:
                    {
                        if (day < 23) return "Leo"; else return "Virgo";
                    }
                case 9:
                    {
                        if (day < 24) return "Virgo"; else return "Libra";
                    }
                case 10:
                    {
                        if (day < 24) return "Libra"; else return "Scorpio";
                    }
                case 11:
                    {
                        if (day < 22) return "Scorpio"; else return "Sagittarius";
                    }
                case 12:
                    {
                        if (day < 22) return "Sagittarius"; else return "Capricorn";
                    }
            }
            return "smth went wrong";
        }

        private  void GetAge()
        {
            var date = DateTime.Today;

            var difference = (date - Birthday);
            var age = difference.Days / 365;

            var sign = GetZodiacSign(Birthday);

            SetImageZodiac(sign);
            Result.Text = ($"User birthday = {Birthday.ToString("dd/MM/yyyy")}, \nhis age is = {age} \nand zodiac sign is {sign}");

        }

        private void SetImageZodiac(string sign)
        {
            signImage.Source = new BitmapImage(new Uri($@"/Images/{sign}.jpg", UriKind.Relative));
        }

        private void closeApp_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
    }


