using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_16
{
    class MyQueue<T>
    {
        public T[] ArrayValues { get; private set; }

        public MyQueue()
        {
        }
        public MyQueue(T value)
        {
            this.ArrayValues = new T[] { value };
        }

        public MyQueue(params T[] values)
        {
            this.ArrayValues = new T[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                this.ArrayValues[i] = values[i];
            }
        }

        public void Enqueue(T value)
        {
            var temp = new T[ArrayValues.Length+1];

            for (var i = 0; i < temp.Length-1; i++)
            {
                temp[i] = ArrayValues[i];
            }

            temp[temp.Length-1] = value;

            this.ArrayValues = temp;
        }

        public void Dequeue()
        {
            var temp = new T[ArrayValues.Length - 1];

            for (var i = 1; i < ArrayValues.Length; i++)
            {
                temp[i-1] = ArrayValues[i];
            }
            this.ArrayValues = temp;

        }

        public T Peek()
        {
            return ArrayValues[0];
        }

        public void PrintValues()
        {
            Console.WriteLine("Printing Queue:");
            for (var i = 0; i< ArrayValues.Length; i++)
            {
                Console.Write($"{i} : {ArrayValues[i]}\n");

            }
        }


    }
}
