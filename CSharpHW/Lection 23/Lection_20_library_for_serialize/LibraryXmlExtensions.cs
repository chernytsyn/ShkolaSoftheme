using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lection_20_library
{
    public static class LibraryXmlExtensions
    {
        public static Book SearchBook(this Library library, string title, string path)
        {
            BookType bt = BookType.None;
            XDocument xDoc = XDocument.Load(path);
            var newBook = new Book();
            var element = xDoc.Root
                                .Elements("Books")
                                .Elements("Book")
                                .Where(b => ((string)b.Element("Name")).Equals(title))
                                .FirstOrDefault();

            if (element != null)
            {
                newBook = new Book(element.Element("Name").Value,
                            element.Element("Author").Value,
                            int.Parse(element.Element("Year").Value),
                            bt.Parse(element.Element("Genre").Value));
            }
            return newBook;
        }

        public static List<Book> SelectBooksWhichContains(this Library lib, string foundValue, string path)
        {
            XDocument xDoc = XDocument.Load(path);
            var searchedBooks = new List<Book>();
            BookType bt = BookType.None;
            var books = xDoc.Root
                            .Elements("Books")
                            .Elements("Book")
                            .Where(b => ((string)b.Element("Name")).Contains(foundValue));

            foreach (XElement element in books)
            {
                searchedBooks.Add(new Book(element.Element("Name").Value,
                            element.Element("Author").Value,
                            int.Parse(element.Element("Year").Value),
                            bt.Parse(element.Element("Genre").Value)));
            }

            return searchedBooks;
        }

        public static void AddBookToXml(this Library lib, Book book, string path)
        {
            XDocument xDoc = XDocument.Load(path);

            xDoc.Descendants("Books").First().Add(
                    new XElement("Book",
                        new XElement("Name", book.Name),
                        new XElement("Author", book.Author),
                        new XElement("Year", book.Year),
                        new XElement("Genre", book.Genre)
                        )
                );
            xDoc.Save(path);
        }

        public static void RemoveBookFromXml(this Library lib, string title, string path)
        {
            XDocument xDoc = XDocument.Load(path);

            var elements = xDoc.Root
                                .Elements("Books")
                                .Elements("Book")
                                .Where(b => ((string)b.Element("Name")).Equals(title))
                                .ToList();

            foreach (XElement elem in elements)
            {
                elem.Remove();
            }
            xDoc.Save(path);
        }
    }
}
