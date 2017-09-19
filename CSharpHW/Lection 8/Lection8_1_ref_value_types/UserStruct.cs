using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection8
{
    struct UserStruct
    {
        private string name;
        private string surname;
        private decimal salary;
        private string email;
        private DateTime applymentsDate;

        public UserStruct(string name, string surname, decimal salary, string email, DateTime applyDate)
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

        public void PrintUser()
        {
            Console.WriteLine($"{this.name} {this.surname}, salary = {this.salary} \n" +
                              $"user email: {this.email}, applyDate:" + String.Format(String.Format("{0:MM/dd/yyyy}", this.applymentsDate)) + "\n");
            Console.ReadKey();
        }

        public static UserStruct Clone(UserStruct obj)
        {
            var tempUser = new UserStruct(obj.name, obj.surname, obj.salary, obj.email, obj.applymentsDate);
            return tempUser;
        }

        public bool Equals(UserStruct obj)
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
