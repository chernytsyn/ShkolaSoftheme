using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();

            Console.ReadLine();

        }
        public static void Test1()
        {
            var simplePrinter = new Printer();
            var colourPrinter = new ColourPrinter();
            var photoPrinter = new PhotoPrinter();

            simplePrinter.Print("");

            colourPrinter.Print();
            colourPrinter.Print("Using method with parameters", colour: ConsoleColor.Magenta);

            photoPrinter.Print();
            photoPrinter.Print(new Image("image"));

            Console.WriteLine("\n\n");

        }

        public static void Test2()
        {
            var simplePrinter = new Printer();
            var colourPrinter = new ColourPrinter();
            var photoPrinter = new PhotoPrinter();

            // Found interesting fact about default values : check what will be shown in console and default values
            // of overrided methods; There's a post on https://habrahabr.ru/post/53576/

            simplePrinter.Print();

            ((Printer)colourPrinter).Print();

            ((Printer)photoPrinter).Print();

        }
    }
}
