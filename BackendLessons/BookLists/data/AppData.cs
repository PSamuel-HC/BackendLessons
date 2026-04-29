using BookClassProgram;
using BookLists.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLists.data
{
    internal class AppData
    {
        /*
            1. DATA STRUCTURES
        
            Create an array of genre, for avoiding duplicate genre lists (Because
            I add genre attrbute in Book class) I prefer to use Enum get values;

            Book List is stored in other file for avoiding a large script
        */
        public static BookGenre[] Genres = (BookGenre[])Enum.GetValues(typeof(BookGenre));

        public static List<Book> Books = BookList.Books;
    }
}
