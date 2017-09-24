using System;

namespace Lection8
{
    struct UserStruct
    {
        private string _name;
        private string _surname;
        private decimal _salary;
        private string _email;
        private DateTime _applymentsDate;

        public UserStruct(string name, string surname, decimal salary, string email, DateTime applyDate)
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

        public void PrintUser()
        {
            Console.WriteLine($"{this._name} {this._surname}, salary = {this._salary} \n" +
                              $"user email: {this._email}, applyDate:" + String.Format(String.Format("{0:MM/dd/yyyy}", this._applymentsDate)) + "\n");
            Console.ReadKey();
        }

        public static UserStruct Clone(UserStruct obj)
        {
            var tempUser = new UserStruct(obj._name, obj._surname, obj._salary, obj._email, obj._applymentsDate);
            return tempUser;
        }

        public bool Equals(UserStruct obj)
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
