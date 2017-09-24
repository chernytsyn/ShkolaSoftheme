using System;

namespace Lection10_arrays_sort
{
    class ArraySort
    {
        public int[] ValuesArray { get; private set; }

        public static Random random;

        static ArraySort()
        {
            random = new Random();
        }

        public ArraySort()
        {
            this.ValuesArray = CreateArray(100);
        }

        public void Sort()
        {
            //BubbleSort(ValuesArray);
            MergeSort(ValuesArray, 0, ValuesArray.Length);
        }

        private int[] MergeSort(int[] array , int left, int right )
        {

            if (left + 1 >= right)
            {
                return array;
            }
            else
            {
                var mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid, right);
                MergeArrays(array,left, mid, right);
            }
            return array;
        }

        private int[] MergeArrays(int[] array, int left, int mid, int right)
        {
            var _it1 = 0;
            var _it2 = 0;

            var result = new int[right - left];

            while (left + _it1 < mid && mid + _it2 < right)
            {
                if (array[left + _it1] < array[mid + _it2])
                {
                    result[_it1 + _it2] = array[left + _it1];
                    _it1 += 1;
                }
                else
                {
                    result[_it1 + _it2] = array[mid + _it2];
                    _it2 += 1;
                }
            }
            while (left + _it1 < mid)
            {
                result[_it1 + _it2] = array[left + _it1];
                _it1 += 1;
            }

            while (mid + _it2 < right)
            {
                result[_it1 + _it2] = array[mid + _it2];
                _it2 += 1;
            }

            for (int i = 0; i < _it1 + _it2; i++)
            {
                array[left + i] = result[i];
            }

            return array;
        }


        public void PrintArray()
        {
            for (int i = 0; i < ValuesArray.Length; i++)
            {
                Console.WriteLine("array[{0}]= {1}", i, ValuesArray[i]);
            }
        }

        public void PrintElement(int index)
        {
            Console.WriteLine("index:{0}, element = {1}", index, ValuesArray[index]);
        }

        private int[] CreateArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i]= random.Next(0, size);
            }
            return array;
        }

        private int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length-1;j>i;j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        array = Swap(j - 1, j, array);
                    }
                }
            }
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

