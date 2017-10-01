using System;

namespace Lection_20_library
{
    class Program
    {
        static void Main(string[] args)
        {

            TestAttributes();

            Console.ReadLine();
        }
        public static void TestAttributes()
        {
            var library = new Library();

            var book = new Book("CLR via C#", "Richter Jeffrey", 2015, BookType.NewsPappers);
            var userAdmin = new User("Vladyslav", "1234", "111-11-11", "test@gmail.com", Rights.admin);

            var testBook = new Book("bookTest", "bookTest", 1000, BookType.None);
            var testUser = new User("UserTest", "UserTest", "UserTest", "UserTest", Rights.none);

            library.AddBook(testBook);
            library.AddUser(testUser);

            library.AddBook(book);
            library.AddUser(userAdmin);

            library.PrintBooks();
            library.PrintUsers();

            library.GetBook(userAdmin, "", "");
            library.GetBook(userAdmin, "CLR via C#", "Richter Jeffrey");
            library.PrintBooks();

            userAdmin.PrintBorrowedBooks();

            library.ReturnBook(userAdmin, "", "");
            library.ReturnBook(userAdmin, "CLR via C#", "Richter Jeffrey");

            library.PrintBooks();
            userAdmin.PrintBorrowedBooks();
        }
    }
}
