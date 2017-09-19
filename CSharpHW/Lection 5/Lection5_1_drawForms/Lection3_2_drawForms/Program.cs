using System;

namespace Lection3_2_drawForms
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DrawFigure(GetFigure());
            }
        }

        private static string GetFigure()
        {
            Console.WriteLine("Figures: triangle,square,romb. \n" 
                + "for exit type : exit or quit \n");

            Console.WriteLine("Enter name of the figure:");
            string figure = Console.ReadLine();
            if (figure.ToLower() == "triangle" || figure.ToLower() == "square" || figure.ToLower() == "romb" ||
                figure.ToLower() == "exit" || figure.ToLower() == "quit")
            {
                return figure.ToLower();
            }
            else return "Error";
        }

        private static void DrawFigure(string type)
        {
            if (type == "triangle")
            {
                DrawTriangle();
            }
            else if (type == "square")
            {
                DrawSquare();
            }
            else if (type == "romb")
            {
                DrawRomb();
            }
            else if (type == "exit" || type == "quir")
            {
                Environment.Exit(0);
            }
        }

        private static void DrawTriangle()
        {
            Console.WriteLine("Enter size of the triangle:");
            int size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine();
                for (int j = size-i; j < size; j++)
                {
                    Console.Write(" * ");
                }
            }
            Console.WriteLine();
        }
        private static void DrawSquare()
        {
            Console.WriteLine("Enter size of the square:");
            int size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < size; j++)
                {
                    Console.Write(" * ");
                }
            }
            Console.WriteLine();
        }
        private static void DrawRomb()
        {
            Console.WriteLine("Enter size of the romb:");
            int size = Convert.ToInt32(Console.ReadLine());

            if (size % 2 != 0) {
                int z = 1;
                for (int i = 0; i < size / 2 + 1; i++)
                {
                    int prob = (size - z) / 2;
                    for (int j = 0; j < prob; j++)
                    {
                        Console.Write(' ');
                    }
                    for (int k = 0; k < z; k++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();

                    z = z + 2;
                }
                z = size - 2;
                for (int i = size / 2; i > 0; i--)
                {
                    int prob = (size - z) / 2;
                    for (int j = 0; j < prob; j++)
                    {
                        Console.Write(' ');
                    }
                    for (int k = 0; k < z; k++)
                    { 
                        Console.Write('*');
                    }
                    Console.WriteLine();
                    z = z - 2;
                }
            } else
            {
                Console.WriteLine("Enter size again, must be unpaired number");
                DrawRomb();
            }
        }
    }
}
