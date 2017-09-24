using System;

namespace Lection_14
{
    class Lottery
    {
        private int[] randomValues;
        private static Random random;

        static Lottery()
        {
            random = new Random();
        }
        public Lottery()
        {
            var tempArray = new int[6];
            for (var i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = random.Next(1, 9);
            }
            this.randomValues = tempArray;
        }

        public string this[int index1, int index2, int index3,
                        int index4, int index5, int index6]
        {
            get
            {
                var tempArray = new int[6] { index1, index2, index3, index4, index5, index6 };
                for (var i = 0; i < randomValues.Length; i++)
                {
                    if (tempArray[i] != randomValues[i])
                    {
                        return "Combination is wrong";
                    }
                }
                return "Combination is correct";
            }
        }

        public static int[] GetCombination()
        {
            var stringValue = Console.ReadLine();
            string[] numbers = stringValue.Split(',');
            var intArray = new int[numbers.Length];
            try
            {
                for (var i = 0; i < intArray.Length; i++)
                {
                    intArray[i] = int.Parse(numbers[i]);
                }
                return intArray;
            }
            catch (Exception)
            { }
            return intArray;
        }

        public void PrintCombination()
        {
            Console.WriteLine("Right combination:\n");
            for (var i = 0; i < randomValues.Length; i++)
            {
                Console.Write(randomValues[i] + ", ");
            }
        }
    }
}
