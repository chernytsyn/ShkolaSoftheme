using System;

namespace Lection_16
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQueue();

            TestStack();

            TestDictionary();

            Console.ReadLine();
        }

        public static void TestQueue()
        {
            Console.WriteLine("Testing Queue \n");

            var test = new MyQueue<int>(1, 2, 3, 4);

            test.Enqueue(5);

            test.PrintValues();

            test.Dequeue();
            test.Dequeue();

            test.PrintValues();
        }

        public static void TestStack()
        {
            Console.WriteLine("Testing Stack \n");

            var test = new MyStack<int>(1, 2, 3, 4);

            test.Push(5);

            test.PrintValues();

            test.Pop();
            test.Pop();

            test.PrintValues();
        }

        public static void TestDictionary()
        {
            Console.WriteLine("Testing Dictionary \n");

            var dictionary = new MyDictionary<int,int>(1,1);

            dictionary.Add(2, 2);

            dictionary.Add(1, 1);

            dictionary.Remove(1);

            dictionary.PrintDictionary();

            Console.ReadLine();
        }
    }

}
