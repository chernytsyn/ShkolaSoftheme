using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection9_enums
{
    public struct FileHandle
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public long FileSize { get; private set; }

        public FileAccessEnum AccessLevel { get; private set; }

        private FileInfo _fileinfo;


        [Flags]
        public enum FileAccessEnum
        {
            None = 0x0,
            Read = 0x1,
            Write = 0x2,
        }

        public FileHandle(string path)
        {
            this.FilePath = path;
            this._fileinfo = new FileInfo(this.FilePath);
            this.FileName = this._fileinfo.Name;
            this.FileSize = this._fileinfo.Length;
            if (_fileinfo.IsReadOnly)
            {
                this.AccessLevel = FileAccessEnum.Read;
            }
            else
            {
                this.AccessLevel = FileAccessEnum.Read | FileAccessEnum.Write;
            }
        }

        public void OpenFile()
        {
            var accessLevel = FileAccessEnum.Read | FileAccessEnum.Write;

            if (this.AccessLevel != accessLevel)
            {
                OpenForRead();
            }
            else
            {
                OpenForWrite();
            }
        }

        public void OpenFile(bool forcedWrite)
        {
            var attributes = File.GetAttributes(this.FilePath);

            if (forcedWrite && this._fileinfo.IsReadOnly)
            {
                File.SetAttributes(this.FilePath, File.GetAttributes(this.FilePath) & ~FileAttributes.ReadOnly);
                OpenForWrite();
                File.SetAttributes(this.FilePath, attributes);
            }
            else if (forcedWrite)
            {
                Console.WriteLine("File wasn't readOnly. Opening for write");
                OpenForWrite();
            }
            else
            {
                Console.WriteLine("\n Unnable to write file due to AccessLevel. Use true parameter to force write");
            }
        }

        public void OpenForRead()
        {
            using (var reader = File.OpenText(this.FilePath))
            {
                var text = reader.ReadToEnd();

                Console.WriteLine("Name: {0} \n{1}", this.FileName, text);

                reader.Close();
                reader.Dispose();
            }
        }

        public void OpenForWrite()
        {
            OpenForRead();
            Console.WriteLine("Adding new text to the file. The text would start" +
                " from another line.\n");

            Console.WriteLine("Enter line:\n");
            var line = GetText();
            line =line + Environment.NewLine + Console.ReadLine();

            File.WriteAllText(this.FilePath, line);

            Console.WriteLine("File after changes: \n");
            OpenForRead();
        }

        private string GetText()
        {
            string fullText;
            using (var reader = File.OpenText(this.FilePath))
            {
                var text = reader.ReadToEnd();
                fullText = text;

                reader.Close();
                reader.Dispose();
            }
            return fullText;
        }
    }
}

