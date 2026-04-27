using BookClassProgram;
using BookLists.models;

namespace BookLists.data
{
    internal static class BookList
    {
        public static List<Book> Books = new List<Book>
        {
            new Book("The Shadow of the Wind", 1, BookGenre.Mystery),
            new Book("Dune", 2, BookGenre.ScienceFiction),
            new Book("The Hobbit", 3, BookGenre.Fantasy),
            new Book("1984", 4, BookGenre.Dystopian),
            new Book("The Da Vinci Code", 5, BookGenre.Thriller),
            new Book("The Shining", 6, BookGenre.Horror),
            new Book("Pride and Prejudice", 7, BookGenre.Romance),
            new Book("Sherlock Holmes: A Study in Scarlet", 8, BookGenre.Detective),
            new Book("Steve Jobs", 9, BookGenre.Biography),
            new Book("The Alchemist", 10, BookGenre.Adventure)
        };
    }
}
