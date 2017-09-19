using System;

namespace Lection2_2_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();

                try
                {

                    int selectedValue;
                    selectedValue = Convert.ToInt32(Console.ReadLine());


                    switch (selectedValue)
                    {
                        case 1:
                            {
                                AdditionMethod();
                                break;
                            }
                        case 2:
                            {
                                SubtractionMethod();
                                break;
                            }
                        case 3:
                            {
                                MultiplicationMethod();
                                break;
                            }
                        case 4:
                            {
                                DivisionMethod();
                                break;
                            }
                        case 5:
                            {
                                RemainderMethod();
                                break;
                            }
                        case 6:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Oops, wrong key. Click any button to continue");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception) { }
            }
        }

        private static void AdditionMethod()
        {
            double lOperand, rOperand;

            Console.Clear();
            Console.WriteLine("You've choosen addition method (+) : ");

            lOperand = GetOperand();
            rOperand = GetOperand();

            var answer = String.Format("{0:0.00}", lOperand+rOperand);

            Console.WriteLine($"{lOperand} + {rOperand} = {answer}");
            Console.ReadKey();

        }

        private static void SubtractionMethod()
        {
            double lOperand, rOperand;

            Console.Clear();
            Console.WriteLine("You've choosen subtraction method (-) : ");

            lOperand = GetOperand();
            rOperand = GetOperand();

            var answer = String.Format("{0:0.00}", lOperand - rOperand);

            Console.WriteLine($"{lOperand} - {rOperand} = {answer}");
            Console.ReadKey();
        }

        private static void  MultiplicationMethod()
        {
            double lOperand, rOperand;

            Console.Clear();
            Console.WriteLine("You've choosen multiplication method (*) : ");

            lOperand = GetOperand();
            rOperand = GetOperand();

            var answer = String.Format("{0:0.00}", lOperand * rOperand);

            Console.WriteLine($"{lOperand} * {rOperand} = {answer}");
            Console.ReadKey();
        }

        private static void DivisionMethod()
        {
            double lOperand, rOperand;

            Console.Clear();
            Console.WriteLine("You've choosen division method (/) : ");

            lOperand = GetOperand();
            rOperand = GetOperand();

            var answer = String.Format("{0:0.00}", lOperand / rOperand);

            Console.WriteLine($"{lOperand} / {rOperand} = {answer}");
            Console.ReadKey();
        }

        private static void RemainderMethod()
        {
            double lOperand, rOperand;

            Console.Clear();
            Console.WriteLine("You've choosen remainder method (%) : ");

            lOperand = GetOperand();
            rOperand = GetOperand();

            var answer = String.Format("{0:0.00}", lOperand % rOperand);

            Console.WriteLine($"{lOperand} % {rOperand} = {answer}");
            Console.ReadKey();
        }

        private static double GetOperand()
        {
            Console.WriteLine("Enter operand:");
            var temp = Convert.ToDouble(Console.ReadLine());
            
            return temp;
        }

        private static void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("Choose the operation to use: \n" +
                              "1. Addiction of the two operands \n" +
                              "2. Substruction of the two operands \n" +
                              "3. Multiplication of the two operands \n" +
                              "4. Division of the two operands \n" +
                              "5. Remainder of the operands \n" +
                              "6. Exit \n");
        }
    }
}
