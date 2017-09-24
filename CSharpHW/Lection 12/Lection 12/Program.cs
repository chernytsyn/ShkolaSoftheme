using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        public static void Test()
        {
            var userDB = new DatabaseOfUsers(new User("vlad","1234","vlad@ukr.net"));

            userDB.PrintAllUsersInfo();

            while (true)
            {
                Console.WriteLine("Enter login");
                var login = Console.ReadLine();

                Console.WriteLine("Enter email");
                var email = Console.ReadLine();

                Console.WriteLine("Enter password");
                var password = Console.ReadLine();

                Console.WriteLine(userDB.ValidateUser(new User(login, password, email)) +"\n");
            }
        }
    }
}
