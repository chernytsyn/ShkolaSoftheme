using System;

namespace Lection10_arrays
{
    class ArrayOperations
    {
        public int[] ValuesArray { get; private set; }

        public static Random random;

        public int UniqueElement { get; private set; }

        static ArrayOperations()
        {
            random = new Random();
        }

        public ArrayOperations()
        {
            this.ValuesArray = ReturnMixedArray(CreateArray());
            this.UniqueElement = FindUniqueElement();
        }

        public void PrintArray()
        {
            foreach (var element in ValuesArray)
            {
                Console.WriteLine(element);
            }
        }

        public void PrintElement(int index)
        {
            Console.WriteLine("index:{0}, element = {1}",index,ValuesArray[index]);
        }

        public int FindIndexOfUniqueElement()
        {
            for (int i = 0; i < ValuesArray.Length; i++)
            {
                if (ValuesArray[i] == UniqueElement)
                {
                    return i;
                }
            }
            return 0;
        }

        private int FindUniqueElement()
        {
            int uniqueValue = 0;

            foreach (var element in ValuesArray)
            {
                uniqueValue = uniqueValue ^ element;
            }

            return uniqueValue;
        }

        private int[] CreateArray()
        {
            var array = new int[101];
            var uniqueValue = random.Next(0, 200);

            array[0] = uniqueValue;

            for (int i = 1; i < array.Length-1; i++)
            {
                var value = random.Next(0, 200);
                if (!value.Equals(uniqueValue))
                {
                    array[i] = value;
                    i++;
                    array[i] = value;
                }
            }
            return array;
        }

        private int[] ReturnMixedArray(int[] array)
        {
            Swap(0, random.Next(0, 101), array);

            for (int i = 0; i < 100; i++)
            {
                RandomSwapValues(array);
            }

            return array;
        }

        private int[] RandomSwapValues(int[] array)
        {
            int _index1 = random.Next(0, 101);
            int _index2 = random.Next(0, 101);

            Swap(_index1, _index2, array);

            return array;
        }

        private int[] Swap(int _index1, int _index2, int[] array)
        {
            int temp = array[_index2];
            array[_index2] = array[_index1];
            array[_index1] = temp;

            return array;
        }

    }
}
