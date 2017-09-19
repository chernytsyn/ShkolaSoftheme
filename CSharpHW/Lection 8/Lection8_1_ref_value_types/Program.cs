using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection8
{
    class Program
    {
        static void Main(string[] args)
        {
            TestUserStruct();
            TestUserRef();

        }

        private static void TestUserRef()
        {
            Console.Clear();
            Console.WriteLine("****************************REFERENCE_TYPE****************************");

            var user1 = new UserRef();
            var user2 = new UserRef("Ivan", "Ivanov", (decimal)500.00, "ivanov@gmail.com", DateTime.Today);
            var user3 = UserRef.Clone(user1);
            var user4 = user1;

            user1.PrintUser();
            user2.PrintUser();
            user3.PrintUser();
            user4.PrintUser();

            Console.WriteLine($"user1 is equal user2 ? answer :{user1.Equals(user2)}");
            Console.WriteLine($"user1 is equal user3 ? answer :{user1.Equals(user3)}");

            Console.WriteLine($"\nComparison of the objects created by clone method \n" +
                              $"user1 is referencing data of user3? {Object.ReferenceEquals(user1,user3)}");
            Console.WriteLine($"\nComparison of the objects created by operator = \n" +
                              $"user1 is referencing data of user4? {Object.ReferenceEquals(user1,user4)} \n");
            
            // changing data in one user - so it changes in another - reference type
            user1.ChangeSalary();

            Console.WriteLine($"\nI've just changed value of user1");

            Console.WriteLine("user1:");
            user1.PrintUser();

            Console.WriteLine("user4:");
            user4.PrintUser();


            Console.ReadKey();
        }

        private static void TestUserStruct()
        {
            Console.Clear();
            Console.WriteLine("****************************STRUCT_TYPE****************************");

            var user1 = new UserStruct("Vladyslav", "Chernytsyn", (decimal)1000.00, "chernytsyn@gmail.com", DateTime.Today);
            var user2 = new UserStruct("Ivan", "Ivanov", (decimal)500.00, "ivanov@gmail.com", DateTime.Today);
            var user3 = UserStruct.Clone(user1);
            var user4 = user1;

            user1.PrintUser();
            user2.PrintUser();
            user3.PrintUser();
            user4.PrintUser();

            Console.WriteLine($"user1 is equal user2 ? answer :{user1.Equals(user2)}");
            Console.WriteLine($"user1 is equal user3 ? answer :{user1.Equals(user3)}");


            Console.WriteLine($"\nComparison of the objects created by clone method \n" +
                              $"user1 is referencing data of user3? {Object.ReferenceEquals(user1, user3)}");
            Console.WriteLine($"\nComparison of the objects created by operator = \n" +
                              $"user1 is referencing data of user4? {Object.ReferenceEquals(user1, user4)} \n");

            // changing data in one user - so it doesn't changes in another - value type
            user1.ChangeSalary();

            Console.WriteLine($"\nI've just changed value of user1");

            Console.WriteLine("user1:");
            user1.PrintUser();

            Console.WriteLine("user4:");
            user4.PrintUser();

            Console.ReadKey();
        }
    }
}
