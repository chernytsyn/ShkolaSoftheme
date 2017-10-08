using System;

namespace Lection_25_hometask_archivator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            var arch = new Archiver();

            arch.CreateArchiveForAllFiles();
            Console.WriteLine("\nNow we are extracting files:\nEnter anything key to continue and then select folder with zipped files");
            Console.ReadLine();
            arch.ExtractFiles();

            Console.ReadLine();
        }
    }
}
