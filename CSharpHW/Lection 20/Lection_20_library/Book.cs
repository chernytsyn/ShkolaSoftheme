using System.ComponentModel.DataAnnotations;

namespace Lection_20_library
{

    public class Book
    {
        [Required(ErrorMessage = "Имя книги не установлено")]
        public string Name { get; private set; }
        [Required(ErrorMessage = "Автор книги не установлено")]
        public string Author { get; private set; }
        [Required(ErrorMessage = "Год издания указан не верно")]
        [Range(1200, 2017)]
        public int Year { get; private set; }
        [Required(ErrorMessage = "Жанр установлен не правильно")]
        [Range(0, 10)]
        [GenreOnlyForViewAttirubute]
        public BookType Genre { get; private set; }

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

    public enum BookType
    {
        None = 0, Satire = 1, Drama = 2, Romance = 3, Detective = 4,
        Science = 5, Non_Fiction = 6,Science_fiction = 7,Comics = 8,
        Dictionaries = 9,NewsPappers = 10
    }
}
