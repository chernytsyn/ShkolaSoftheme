using System;

using Lection_11;

namespace Lection_11_addition_methods
{
    static class AdditionsMethod
    {
        public static void PrintArrayOfText(this Printer printer, string[] textArray)
        {
            foreach (string line in textArray)
            {
                printer.Print(line);
            }
        }

        public static void PrintArrayOfColouredText(this ColourPrinter colourPrinter, string[] textArray, ConsoleColor[] colours)
        {
            for (var i = 0; i < textArray.Length; i++)
            {
                if (i < colours.Length)
                {
                    colourPrinter.Print(textArray[i], colours[i]);
                }
                else
                {
                    colourPrinter.Print(textArray[i]);
                }
            }
        }

        public static void PrintArrayOfPhotos(this PhotoPrinter photoPrinter, Image[] images)
        {
            foreach (Image image in images)
            {
                photoPrinter.Print(image);
            }
        }
    }
}
