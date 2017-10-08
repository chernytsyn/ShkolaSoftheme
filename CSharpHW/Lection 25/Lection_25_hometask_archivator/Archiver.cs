using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace Lection_25_hometask_archivator
{
    class Archiver
    {
        public string UserPath { get; private set; }

        public string[] AllFilePathes { get; private set; }

        const string ArchivePath = "../../TestDirectory/ZippedFiles/";
        const string ExtractPath = "../../TestDirectory/ExtractFiles/";

        private Random random;


        public Archiver()
        {
            this.random = new Random();
        }

        public void CreateArchiveForAllFiles()
        {
            ShowPathSelectionDialog();
            GetAllFilePathes(false);

            foreach (string s in AllFilePathes)
            {
                Thread newThread = new Thread(() => this.CompressFile(s));
                newThread.Start();
                newThread.Join();
            }
        }

        public void ExtractFiles()
        {
            ShowPathSelectionDialog();
            GetAllFilePathes(true);

            foreach (string s in AllFilePathes)
            {
                Thread newThread = new Thread(() => this.DecompressFile(s));
                newThread.Start();
                newThread.Join();
            }
        }

        private void CompressFile(string sourceFile)
        {
            var fileName = Path.GetFileName(sourceFile);

            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(ArchivePath + fileName +".gz"))
                using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                {
                    sourceStream.CopyTo(compressionStream);
                    Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                        sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                }
            }
        }

        private void DecompressFile(string sourceFile)
        {
            var fileName = Path.GetFileName(sourceFile.Substring(0,sourceFile.Length- ".gz".Length));

            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(ExtractPath + fileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", ExtractPath + fileName);
                    }
                }
            }
        }

        public void ShowPathSelectionDialog()
        {
            lock (this)
            {
                Thread newThread = new Thread(this.SetPath);
                newThread.SetApartmentState(ApartmentState.STA);
                newThread.Start();
                newThread.Join();
            }
        }

        private void GetAllFilePathes(bool checkForZip)
        {
            try
            {
                var allPathes = Directory.GetFileSystemEntries(this.UserPath, "*", SearchOption.AllDirectories);
                var tempPathes = new List<string>();

                foreach (string s in allPathes)
                {
                    if (checkForZip)
                    {
                        if (File.Exists(s) &&  s.EndsWith(".gz"))
                        {
                            tempPathes.Add(s);
                        }
                    }
                    else
                    {
                        if (File.Exists(s))
                        {
                            tempPathes.Add(s);
                        }
                    }
                }
                this.AllFilePathes = tempPathes.ToArray();
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please select folder next time");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private void SetPath()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ValidateNames = false;
            fd.CheckFileExists = false;
            fd.CheckPathExists = true;
            fd.FileName = "Select folder";
            var additionalLength = fd.FileName.Length;
            fd.ShowDialog();
            if (fd.CheckFileExists)
            {
                this.UserPath = fd.FileName;
            }
            else
            {
                this.UserPath = fd.FileName.Substring(0, fd.FileName.Length - additionalLength);
            }
        }
    }
}
