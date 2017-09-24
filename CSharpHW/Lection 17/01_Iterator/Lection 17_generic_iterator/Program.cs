using System;

namespace Lection_17_generic_iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            TestIteratorInt();
            Console.WriteLine("\n\n");

            TestIteratorString();
            Console.WriteLine("\n\n");

            TestIteratorWrapper();
            Console.ReadKey();
        }

        public static void TestIteratorString()
        {
            var a = new Aggregate<string>();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            var i = new Iterator<string>(a);

            Console.WriteLine("Using generic pattern Iterator:\nIterating over collection:");

            var item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
        }
        public static void TestIteratorInt()
        {
            var a = new Aggregate<int>();
            a[0] = 1;
            a[1] = 2;
            a[2] = 3;
            a[3] = 4;

            var i = new Iterator<int>(a);

            Console.WriteLine("Using generic pattern Iterator:\nIterating over collection:");

            var item = i.First();
            while (item != default(int))
            {
                Console.WriteLine(item);
                item = i.Next();
            }
        }

        public static void TestIteratorWrapper()
        {
            var a = new Aggregate<Wrapper>();
            a[0] = new Wrapper();
            a[1] = new Wrapper("1",1);
            a[2] = new Wrapper("2",2);
            a[3] = new Wrapper("3",3);

            var i = new Iterator<Wrapper>(a);

            Console.WriteLine("Using generic pattern Iterator:\nIterating over collection:");

            var item = i.First();
            while (item != null)
            {
                Console.WriteLine(item.ToString());
                item = i.Next();
            }
        }
    }
}
