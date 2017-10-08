namespace Lection_20_library
{
    public static class BookTypeExtension
    {
        public static BookType Parse(this BookType bt, string value)
        {
            BookType bookTypeTemp = BookType.None;
            switch (value)
            {
                case "Satire":
                    bookTypeTemp = BookType.Satire;
                    break;
                case "Drama":
                    bookTypeTemp = BookType.Drama;
                    break;
                case "Romance":
                    bookTypeTemp = BookType.Romance;
                    break;
                case "Detective":
                    bookTypeTemp = BookType.Detective;
                    break;
                case "Science":
                    bookTypeTemp = BookType.Science;
                    break;
                case "Non_Fiction":
                    bookTypeTemp = BookType.Non_Fiction;
                    break;
                case "Science_fiction":
                    bookTypeTemp = BookType.Science_fiction;
                    break;
                case "Comics":
                    bookTypeTemp = BookType.Comics;
                    break;
                case "Dictionaries":
                    bookTypeTemp = BookType.Dictionaries;
                    break;
                case "NewsPappers":
                    bookTypeTemp = BookType.NewsPappers;
                    break;
                default:
                    bookTypeTemp = BookType.None;
                    break;
            }
            return bookTypeTemp;
        }
    }
}
