using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lection_20_library
{
    
    public class Library
    {
        public List<Book> Books { get; private set; }
        public List<User> Users { get; private set; }

        public Library()
        {
            this.Books = new List<Book>();
            this.Users = new List<User>();
        }

        public Library(Book book, User user)
        {
            this.Books = new List<Book>();
            this.Users = new List<User>();

            AddBook(book);
            AddUser(user);
        }

        public Library(List<Book> books, List<User> users)
        {
            this.Books = books;
            this.Users = users;
        }

        public void AddBook(Book newBook)
        {
            if (Validate(newBook))
            {
                this.Books.Add(newBook);
            }
        }

        public void AddUser(User newUser)
        {
            if (Validate(newUser))
            {
                this.Users.Add(newUser);
            }
        }

        public void GetBook(User borrowingUser, string name, string author)
        {
            if (CheckUser(borrowingUser))
            {
                var bookForBorrow = this.Books.FirstOrDefault(book => book.Name == name && book.Author == author);
                if (bookForBorrow != null)
                {
                    if (Validate(bookForBorrow)) ;
                    this.Books.Remove(bookForBorrow);
                    borrowingUser.BorrowedBooks.Add(bookForBorrow);
                    Console.WriteLine("\nBook: {0} was borrowed\n",bookForBorrow.Name);
                }
                else
                {
                    Console.WriteLine("Book not found");
                }
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }

        public void ReturnBook(User userThatReturnsBook, string name, string author)
        {
            if (CheckUser(userThatReturnsBook))
            {
                var bookForReturn = userThatReturnsBook.BorrowedBooks.FirstOrDefault(book => book.Name == name &&
                                                                                book.Author == author);
                if (bookForReturn != null)
                {
                    var returnedBook = userThatReturnsBook.ReturnBook(name, author);
                    this.Books.Add(returnedBook);
                    Console.WriteLine("\nBook: {0} was returned\n",returnedBook.Name);
                }
                else
                {
                    Console.WriteLine("User does not have this book");
                }
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }

        public bool CheckUser(User borrowingUser) => this.Users.Any(user => user.Name == borrowingUser.Name &&
                                                                    user.Password == borrowingUser.Password);

        public void PrintUsers()
        {
            Console.WriteLine("\nPrinting users:");

            foreach (User u in this.Users)
            {
                Console.WriteLine("UserName: {0}, Email: {1}\nRights:{2}\n",u.Name,u.Email,u.UserRights.ToString());
            }
        }

        public void PrintBooks()
        {
            Console.WriteLine("\nPrinting books:");

            foreach (Book b in this.Books)
            {
                Console.WriteLine("Book: {0}, Auhtor: {1}\nYear:{2}\n",b.Name,b.Author,b.Year);
            }
        }

        private static bool Validate(User user)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }
            else
            {
                Console.WriteLine("Пользователь прошел валидацию");
                return true;
            }
        }

        private static bool Validate(Book book)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(book);
            if (!Validator.TryValidateObject(book, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }
            else
            {
                Console.WriteLine("Книга прошла валидацию");
                return true;
            }
        }
    }
}
