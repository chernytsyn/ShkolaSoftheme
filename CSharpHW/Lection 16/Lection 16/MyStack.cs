using System;

namespace Lection_16
{
    class MyStack<T>
    {
        public T[] ArrayValues { get; private set; }

        public MyStack()
        {

        }
        public MyStack(T value)
        {
            this.ArrayValues = new T[] { value };
        }

        public MyStack(params T[] values)
        {
            this.ArrayValues = new T[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                this.ArrayValues[i] = values[i];
            }
        }

        public void Push(T value)
        {
            var temp = new T[ArrayValues.Length + 1];

            for (var i = 0; i < temp.Length - 1; i++)
            {
                temp[i] = ArrayValues[i];
            }

            temp[temp.Length - 1] = value;

            this.ArrayValues = temp;
        }

        public void Pop()
        {
            var temp = new T[ArrayValues.Length - 1];

            for (var i = 0; i < ArrayValues.Length-1; i++)
            {
                temp[i] = ArrayValues[i];
            }
            this.ArrayValues = temp;
        }
      
        public T Peek()
        {
            return ArrayValues[0];
        }

        public void PrintValues()
        {
            Console.WriteLine("Printing Stack:");
            for (var i = 0; i < ArrayValues.Length; i++)
            {
                Console.Write($"{i} : {ArrayValues[i]}\n");

            }
        }
    }
}
