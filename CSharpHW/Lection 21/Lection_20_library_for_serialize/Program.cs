using System;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;

namespace Lection_20_library
{
    class Program
    {
        static void Main(string[] args)
        {

            TestBinary();
            TestJson();
            TestXML();

            Console.ReadLine();
        }
        
        public static void TestBinary()
        {
            Stopwatch sw = new Stopwatch();

            var library = new Library(new Book("123","123",2017,BookType.Comics),
                                        new User("vlad","1234","111-11-11","test@gmail.com",Rights.admin));

            Library libraryDeserialized;

            sw.Start();
            BinaryFormatter formater = new BinaryFormatter();

            using (FileStream fs = new FileStream("library.dat", FileMode.OpenOrCreate))
            {

                formater.Serialize(fs,library);
            }

            using (FileStream fs = new FileStream("library.dat", FileMode.OpenOrCreate))
            {
                libraryDeserialized = (Library)formater.Deserialize(fs);
            }

            sw.Stop();
            Console.WriteLine("Time needed for binary serialize/deserialize = {0}",sw.Elapsed);
        }

        public static void TestJson()
        {
            Stopwatch sw = new Stopwatch();

            var library = new Library(new Book("123", "123", 2017, BookType.Comics),
                                        new User("vlad", "1234", "111-11-11", "test@gmail.com", Rights.admin));

            Library libraryDeserialized;

            sw.Start();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Library));

            using (FileStream fs = new FileStream("library.json", FileMode.OpenOrCreate))
            {

                serializer.WriteObject(fs, library);
            }

            using (FileStream fs = new FileStream("library.json", FileMode.OpenOrCreate))
            {
                libraryDeserialized = (Library)serializer.ReadObject(fs);
            }

            sw.Stop();
            Console.WriteLine("Time needed for json serialize/deserialize = {0}", sw.Elapsed);

        }

        public static void TestXML()
        {
            Stopwatch sw = new Stopwatch();

            var library = new Library(new Book("123", "123", 2017, BookType.Comics),
                                        new User("vlad", "1234", "111-11-11", "test@gmail.com", Rights.admin));

            Library libraryDeserialized;

            sw.Start();
            XmlSerializer serializer = new XmlSerializer(typeof(Library));

            using (FileStream fs = new FileStream("library.xml", FileMode.OpenOrCreate))
            {

                serializer.Serialize(fs, library);
            }

            using (FileStream fs = new FileStream("library.xml", FileMode.OpenOrCreate))
            {
                libraryDeserialized = (Library)serializer.Deserialize(fs);
            }

            sw.Stop();
            Console.WriteLine("Time needed for XML serialize/deserialize = {0}", sw.Elapsed);

        }
    }
}
