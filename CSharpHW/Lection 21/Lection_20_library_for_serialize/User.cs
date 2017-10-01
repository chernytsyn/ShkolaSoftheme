using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Lection_20_library
{
    [Serializable]
    public class User
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(1, 2)]
        public Rights UserRights { get; set; }

        public List<Book> BorrowedBooks { get; set; }

        public User() { }

        public User(string name, string password,string phone, string email, Rights userRights)
        {
            this.Name = name;
            this.Password = password;
            this.Phone = phone;
            this.Email = email;
            this.UserRights = userRights;
            this.BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book borrowedBook)
        {
            this.BorrowedBooks.Add(borrowedBook);
        }

        public Book ReturnBook(string name, string author)
        {
            var bookForReturn = this.BorrowedBooks.First(book => book.Name == name && book.Author == author);
            this.BorrowedBooks.Remove(bookForReturn);
            return bookForReturn;
        }

        public void PrintBorrowedBooks()
        {
            Console.WriteLine("\nUserName: {0}, Printing borrowed books:",this.Name);

            foreach (Book b in this.BorrowedBooks)
            {
                Console.WriteLine("Book: {0}, Auhtor: {1}\nYear:{2}\n", b.Name, b.Author, b.Year);
            }
        }
    }

    public enum Rights
    {
        none = 0, employee = 1, admin = 2
    }

}
