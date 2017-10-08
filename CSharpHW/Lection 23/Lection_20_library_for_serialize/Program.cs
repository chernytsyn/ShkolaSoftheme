using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;


namespace Lection_20_library
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateXmlLibrary();
            TestSearchFromXml("Spider-Man #18", "library.xml");
            SelectionFromXml("#1", "library.xml");
            AddingBookToXml(new Book(), "library.xml");
            TestSearchFromXml("default name", "library.xml");
            DeleteBookFromXml(new Book(), "library.xml");
            TestSearchFromXml("default name", "library.xml");

            Console.ReadLine();
        }

        public static void TestSearchFromXml(string title, string path)
        {
            Book book = new Library().SearchBook(title, path);
            Console.WriteLine($"{book.Name} : author: {book.Author} \nGenre:{book.Genre} \nYear:{book.Year}");
        }

        public static void SelectionFromXml(string substring, string path)
        {
            var books = new Library().SelectBooksWhichContains(substring, path);

            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Name} : author: {book.Author} \nGenre:{book.Genre} \nYear:{book.Year}");
            }
        }

        public static void AddingBookToXml(Book book, string path)
        {
            new Library().AddBookToXml(book, path);
        }

        public static void DeleteBookFromXml(Book book, string path)
        {
            new Library().RemoveBookFromXml(book.Name, path);
        }

        public static void CreateXmlLibrary()
        {
            Stopwatch sw = new Stopwatch();

            var library = new Library(new Book("Spider-Man #1", "Stan Lee", 1963, BookType.Comics),
                                        new User("Vladyslav Chernytsyn", "1234", "111-11-11", "test@gmail.com", Rights.admin));
            for (var i = 2; i < 22; i++)
            {
                library.AddBook(new Book($"Spider-Man #{i}", "Stan Lee", 1963+i,BookType.Comics));
            }

            sw.Start();
            SerializeLibrary(library);
            sw.Stop();
            Console.WriteLine("Time needed for XML serialize = {0}", sw.Elapsed);
        }

        public static void SerializeLibrary(Library library)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));

            using (FileStream fs = new FileStream("library.xml", FileMode.OpenOrCreate))
            {

                serializer.Serialize(fs, library);
            }
        }
    }
}
