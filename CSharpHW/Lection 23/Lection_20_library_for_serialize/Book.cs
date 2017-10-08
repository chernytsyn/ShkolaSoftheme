using System;
using System.ComponentModel.DataAnnotations;

namespace Lection_20_library
{
    [Serializable]
    public class Book
    {
        [Required(ErrorMessage = "Имя книги не установлено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Автор книги не установлено")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Год издания указан не верно")]
        [Range(1200, 2017)]
        public int Year { get; set; }
        [Required(ErrorMessage = "Жанр установлен не правильно")]
        [Range(0, 10)]
        [GenreOnlyForViewAttirubute]
        public BookType Genre { get; set; }

        public Book() :
            this("default name", "default author", 2017, BookType.None)
        {
        }

        public Book(string name, string author, int year, BookType genre)
        {
            this.Name = name;
            this.Author = author;
            this.Year = year;
            this.Genre = genre;
        }
    }
}
