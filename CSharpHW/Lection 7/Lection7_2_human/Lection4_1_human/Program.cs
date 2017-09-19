using System;

namespace Lection4_1_human
{
    public class Human
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; }

        public Human()
        {
            this.Firstname = "Vlad";
            this.Lastname = "Chernytsyn";
            this.Birthday = DateTime.Today;
            this.Age = 21;
        }

        public Human(string fName, string lName, DateTime birthday)
            : this(fName, lName, birthday, 22)
        {
        }

        public Human(string fName, string lName, DateTime birthday, int age)
        {
            this.Firstname = fName;
            this.Lastname = lName;
            this.Birthday = birthday;
            this.Age = age;
        }

        public override bool Equals(object obj)
        {
            if (obj is Human)
            {
                var human = (Human)obj;

                if (this.Firstname != human.Firstname)
                {
                    return false;
                }
                else if (this.Lastname != human.Lastname)
                {
                    return false;
                }
                else if (this.Birthday != human.Birthday)
                {
                    return false;
                }
                else if (this.Age != human.Age)
                {
                    return false;
                }
                return true;
            }
            else return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var h1 = new Human(); 
            var h2 = new Human("dima", "ivanov", DateTime.Today);
            var h3 = new Human("Vlad", "Chernytsyn", DateTime.Today, 21);

            Console.WriteLine($"Testing equals overrited method \nh1 equals h2, result : {h1.Equals(h2)} \n"
                + $"h1 equals h3, result : {h1.Equals(h3)}");
            Console.ReadKey();
        }
    }
}
