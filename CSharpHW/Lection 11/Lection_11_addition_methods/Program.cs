using System;

using Lection_11;

namespace Lection_11_addition_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            var colourPrinter = new ColourPrinter();
            var photoPrinter = new PhotoPrinter();

            printer.PrintArrayOfText(new string[] { "hello ", "world" });

            colourPrinter.PrintArrayOfColouredText(new string[] { "colour ", "text", "example" },
                                        new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.Red });

            photoPrinter.PrintArrayOfPhotos(new Image[] { new Image("Image1"), new Image("Image2") });


            Console.ReadLine();

        }
    }
}
