using System;

namespace Lection_11
{
    public class Printer
    {
        public Printer() { }
        public virtual void Print(string printedValue = "Base class default value")
        {
            Console.WriteLine(printedValue);
            Console.WriteLine("Base PrinterMethod was used\n");
        }
    }
    public class ColourPrinter:Printer
    {
        public ColourPrinter() { }
        public override void Print(string printedColourValue = "ColourPrinter default value")
        {
            Console.WriteLine(printedColourValue);
            Console.WriteLine("ColourPrinterMethod was used\n");
        }
        public void Print(string printedColourValue, ConsoleColor colour = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(printedColourValue);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    public class PhotoPrinter:Printer
    {
        public PhotoPrinter() { }
        public override void Print(string printedPhotoValue = "PhotoPrinter default value")
        {
            Console.WriteLine(printedPhotoValue);
            Console.WriteLine("PhotoPrinterMethod was used\n");
        }
        public void Print(Image image)
        {
            Console.WriteLine(image.Name);
        }
    }

    public class Image
    {
        public string Name { get; private set; }

        public Image(string name)
        {
            this.Name = name;
        }
    }
}
