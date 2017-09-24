using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Lottery lottery = new Lottery();
            lottery.PrintCombination();

            while (true)
            {

                Console.WriteLine("\nEnter six elements: (splitted with ',' )");
                var combination = Lottery.GetCombination();
                try
                {
                    Console.WriteLine(lottery[combination[0], combination[1], combination[2], combination[3],
                                                              combination[4], combination[5]]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nIncorrect input, Try again (example: 1,1,1,1,1,1) \n\n");
                }
            }
        }
    }
}
