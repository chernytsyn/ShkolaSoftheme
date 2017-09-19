using System;

namespace Lection2_3_zodiac
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAge();
            Console.ReadKey();
        }

        private static void GetAge()
        {
            var birthday = SetBirthday();
            var date = DateTime.Today;

            var difference = (date - birthday);
            var age = difference.Days / 365;

            var sign = GetZodiacSign(birthday);

            Console.WriteLine($"User birthday = {birthday.ToString("dd/MM/yyyy")}, his age is = {age} and zodiac sign is {sign}");

        }

        private static string GetZodiacSign(DateTime birthday)
        {
            var month = birthday.Month;
            var day = birthday.Day;
            switch (month) {
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
        private static DateTime GetUserBirthDate(int day = 0, int month = 0, int year = 0)
        {
            Console.Clear();

            var i_day = day;
            var i_month = month;
            var i_year = year;

            if (i_day == 0)
            {
                i_day = GetDay();
            }

            if (i_month == 0)
            {
                i_month = GetMonth();
            }

            if (i_year == 0)
            {
                i_year = GetYear();
            }

            if (i_day > 31 || i_day < 1)
            {
                return GetUserBirthDate(month:i_month,year:i_year);
            }

            if (i_month > 12 || i_month < 1)
            {
                return GetUserBirthDate(day:i_day,year:i_year);
            }

            else if (i_year > 2150 || i_year < 1940)
            {
                return GetUserBirthDate(day:i_day, month:i_month);
            }

            DateTime birthday = new DateTime(i_year, i_month, i_day);

            return birthday;
        }

        private static DateTime SetBirthday()
        {
            Console.WriteLine("Enter your birthday in the given format dd/mm/yy");
            try
            {
                var s_birthday = Console.ReadLine();
                string[] dateParts = s_birthday.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                var s_day = dateParts[0];
                var s_month = dateParts[1];
                var s_year = dateParts[2];

                var i_day = Convert.ToInt32(s_day);
                var i_month = Convert.ToInt32(s_month);
                var i_year = Convert.ToInt32(s_year);

                DateTime birthday = GetUserBirthDate(i_day, i_month, i_year);
                return birthday;
            }
            catch (Exception)
            {
                return SetBirthday();
            }

        }

        private static int GetDay()
        {
            Console.WriteLine("Enter day of birth");
            try
            {
                int day = Convert.ToInt32(Console.ReadLine());
                return day;
            }
            catch (Exception)
            {
                return GetDay();
            }

        }
        private static int GetMonth()
        {
            Console.WriteLine("Enter Month of birth");
            try
            {
                int month = Convert.ToInt32(Console.ReadLine());
                return month;
            }
            catch (Exception)
            {
                return GetMonth();
            }
        }
        private static int GetYear()
        {
            Console.WriteLine("Enter year of birth");
            try
            {
                int year = Convert.ToInt32(Console.ReadLine());
                return year;
            }
            catch (Exception)
            {
                return GetYear();
            }
        }
    }
}
