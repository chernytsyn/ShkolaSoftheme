using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection9_enums
{
    class Program
    {
        static void Main(string[] args)
        {
            TestOpenFile();

            TestWrite();

            TestForceWrite();
        }

        public static void TestOpenFile()
        {
            Console.Clear();

            var fileHandleRead = new FileHandle("ReadOnly.txt");
            fileHandleRead.OpenFile();

            Console.WriteLine("\nTest for OpenFile finished. Enter anything to continue");
            Console.ReadLine();
        }

        public static void TestWrite()
        {
            Console.Clear();

            var fileHandleReadAndWrite = new FileHandle("OpensForReadAndWrite.txt");
            fileHandleReadAndWrite.OpenFile();

            Console.WriteLine("\nTest for OpenWrite finished. Enter anything to continue");
            Console.ReadLine();
        }

        public static void TestForceWrite()
        {
            Console.Clear();

            var fileHandleForceWrite = new FileHandle("ForceWriteExample.txt");

            Console.WriteLine("Calling method with false parameter:\n");
            fileHandleForceWrite.OpenFile(false);
            Console.WriteLine("\n Now calling method with true parameter\n");
            fileHandleForceWrite.OpenFile(true);

            Console.WriteLine("\nTest for OpenForceWrite finished. Enter anything to continue");
            Console.ReadLine();
        }
    }
}
