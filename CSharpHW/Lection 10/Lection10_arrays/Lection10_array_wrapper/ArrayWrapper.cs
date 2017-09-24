using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lection10_array_wrapper
{
    class ArrayWrapper<TArray>
        where TArray : new()
    {
        public TArray[] ValueArray { get; private set; }

        public int LastIndex { get; private set; }

        public ArrayWrapper()
        {
            this.ValueArray = new TArray[] { new TArray() };
            LastIndex = ValueArray.Length;
        }

        public ArrayWrapper(TArray[] array)
        {
            this.ValueArray = array;
            LastIndex = ValueArray.Length;
        }

        public void Add(TArray element)
        {
            if (LastIndex == ValueArray.Length)
            {
                var tempArray = new TArray[ValueArray.Length + 5];

                for (int i = 0; i < ValueArray.Length; i++)
                {
                    tempArray[i] = ValueArray[i];
                }
                this.ValueArray = tempArray;
                
                ValueArray[LastIndex] = element;
                LastIndex++;
            }
            else
            {
                ValueArray[LastIndex] = element;
                LastIndex++;
            }
        }
        public void PrintArray()
        {
            for (int i = 0; i < LastIndex; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, ValueArray[i]);
            }
        }
    }

}
