using System;

namespace Lection8
{
    class UserRef
    {
        private string _name;
        private string _surname;
        private decimal _salary;
        private string _email;
        private DateTime _applymentsDate;

        public UserRef()
        {
            Console.WriteLine("Enter your name");
            this._name = Console.ReadLine();

            Console.WriteLine("Enter your surname");
            this._surname = Console.ReadLine();

            try
            {
                Console.WriteLine("Enter your salary");
                this._salary = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid value, default 0 salary was sumbitted");
                this._salary = default(decimal);
            }

            Console.WriteLine("Enter your email");
            this._email = Console.ReadLine();

            this._applymentsDate = DateTime.Today;

        }


        public UserRef(string name, string surname, decimal salary, string email, DateTime applyDate)
        {
            this._name = name;
            this._surname = surname;
            this._salary = salary;
            this._email = email;
            this._applymentsDate = applyDate;
        }

        public void ChangeSalary()
        {
            Console.WriteLine("Enter new salary");
            try
            {
                this._salary = Convert.ToDecimal(Console.ReadLine());
            }
            catch (InvalidCastException)
            {
                Console.WriteLine($"You've entered wrong values, nothing changed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("unhandled exception: \n" + ex.ToString());
            }
        }

        public static UserRef Clone(UserRef obj)
        {
            var tempUser = new UserRef(obj._name, obj._surname, obj._salary, obj._email, obj._applymentsDate);
            return tempUser;
        }

        public void PrintUser()
        {
            Console.WriteLine($"{this._name} {this._surname}, salary = {this._salary} \n" +
                              $"user email: {this._email}, applyDate:" + String.Format(String.Format("{0:MM/dd/yyyy}", this._applymentsDate)) + "\n");
            Console.ReadKey();
        }

        public bool Equals(UserRef obj)
        {
            if (this._name != obj._name)
                return false;

            if (this._surname != obj._surname)
                return false;

            if (this._salary != obj._salary)
                return false;

            if (this._email != obj._email)
                return false;

            if (this._applymentsDate != obj._applymentsDate)
                return false;

            return true;
        }
    }
}
