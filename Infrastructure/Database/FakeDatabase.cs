using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> Books { get { return allBooksFromDB; } set { allBooksFromDB = value; } }

        private static List<Book> allBooksFromDB = new List<Book>
        {
            new Book (1, "Book1", "History"),
            new Book (2, "Book2", "Biography"),
            new Book (3, "Book3", "Programming"),
            new Book (4, "Book4", "Science fiction"),
            new Book (5, "Book5", "Fantasy")
        };

        public Book AddNewBook(string title, string genre)
        {
            Book newBookToAdd = new Book(allBooksFromDB.Max(x => x.Id) + 1, title, genre);
            allBooksFromDB.Add(newBookToAdd);
            return newBookToAdd;
        }

        public Book GetBookById(int id)
        {
            return allBooksFromDB.FirstOrDefault(book => book.Id == id);
        }

        public List<Book> GetAllBooks()
        {
            return allBooksFromDB;
        }

        public bool UpdateBook(Book updatedBook)
        {
            var existingBook = GetBookById(updatedBook.Id);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Genre = updatedBook.Genre;
                return true;
            }
            return false;
        }

        public bool DeleteBook(int id)
        {
            var bookToDelete = GetBookById(id);
            if (bookToDelete != null)
            {
                allBooksFromDB.Remove(bookToDelete);
                return true;
            }
            return false;
        }

        /// <summary>
        /// /////////////////////
        /// </summary>

        public List<Author> Authors { get { return allAuthorsFromDB; } set { allAuthorsFromDB = value; } }

        private static List<Author> allAuthorsFromDB = new List<Author>
        {
            new Author (1, "Hans Rosling"),
            new Author (2, "Robert Sapolsky")
        };

        public Author AddNewAuthor(string name)
        {
            Author newAuthorToAdd = new Author(allAuthorsFromDB.Max(x => x.Id) + 1, name);
            allAuthorsFromDB.Add(newAuthorToAdd);
            return newAuthorToAdd;
        }

        public Author GetAuthorById(int id)
        {
            return allAuthorsFromDB.FirstOrDefault(author => author.Id == id);
        }

        public List<Author> GetAllAuthors()
        {
            return allAuthorsFromDB;
        }

        public bool UpdateAuthor(Author updatedAuthor)
        {
            var existingAuthor = GetAuthorById(updatedAuthor.Id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = updatedAuthor.Name;
                return true;
            }
            return false;
        }

        public bool DeleteAuthor(int id)
        {
            var authorToDelete = GetAuthorById(id);
            if (authorToDelete != null)
            {
                allAuthorsFromDB.Remove(authorToDelete);
                return true;
            }
            return false;
        }

    }
}
