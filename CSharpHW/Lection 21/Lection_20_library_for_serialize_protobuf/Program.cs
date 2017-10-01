using System;
using System.Diagnostics;
using System.IO;
using ProtoBuf;

namespace Lection_20_library
{
    class Program
    {
        static void Main(string[] args)
        {

            TestProtobuf();

            Console.ReadLine();
        }
        
        public static void TestProtobuf()
        {
            Stopwatch sw = new Stopwatch();

            var library = new Library(new Book("123","123",2017,BookType.Comics),
                                        new User("vlad","1234","111-11-11","test@gmail.com",Rights.admin));

            Library libraryDeserialized;

            sw.Start();

            using (FileStream fs = new FileStream("library-protobuf.dat", FileMode.OpenOrCreate))
            {

                Serializer.Serialize(fs, library);
            }

            using (FileStream fs = new FileStream("library-protobuf.dat", FileMode.OpenOrCreate))
            {
                libraryDeserialized = Serializer.Deserialize<Library>(fs);
            }

            sw.Stop();
            Console.WriteLine("Time needed for protobuf-net serialize/deserialize = {0}",sw.Elapsed);
        }
    }
}
