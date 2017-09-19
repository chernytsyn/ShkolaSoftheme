using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Lection8
{
    class UserRef
    {
        private string name;
        private string surname;
        private decimal salary;
        private string email;
        private DateTime applymentsDate;

        public UserRef()
        {
            Console.WriteLine("Enter your name");
            this.name = Console.ReadLine();

            Console.WriteLine("Enter your surname");
            this.surname = Console.ReadLine();

            try
            {
                Console.WriteLine("Enter your salary");
                this.salary = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid value, default 0 salary was sumbitted");
                this.salary = default(decimal);
            }

            Console.WriteLine("Enter your email");
            this.email = Console.ReadLine();

            this.applymentsDate = DateTime.Today;

        }


        public UserRef(string name, string surname, decimal salary, string email, DateTime applyDate)
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
            this.email = email;
            this.applymentsDate = applyDate;
        }

        public void ChangeSalary()
        {
            Console.WriteLine("Enter new salary");
            try
            {
                this.salary = Convert.ToDecimal(Console.ReadLine());
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
            var tempUser = new UserRef(obj.name,obj.surname,obj.salary,obj.email,obj.applymentsDate);
            return tempUser;
        }

        public void PrintUser()
        {
            Console.WriteLine($"{this.name} {this.surname}, salary = {this.salary} \n" +
                              $"user email: {this.email}, applyDate:" + String.Format(String.Format("{0:MM/dd/yyyy}", this.applymentsDate)) + "\n");
            Console.ReadKey();
        }

        public bool Equals(UserRef obj)
        {
            if (this.name != obj.name)
                return false;

            if (this.surname != obj.surname)
                return false;

            if (this.salary != obj.salary)
                return false;

            if (this.email != obj.email)
                return false;

            if (this.applymentsDate != obj.applymentsDate)
                return false;

            return true;
        }
    }
}
