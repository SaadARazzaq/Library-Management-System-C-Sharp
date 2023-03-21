using System;

namespace Library_Management_System_Using_C_Sharp
{
    public enum Genre
    {
        Fiction,
        Philosophy,
        Religion
    }

    public class Book
    {
        private static Book[] catalog = new Book[0];

        public Genre Type { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public Book(string Title, string Author, string ISBN)
        {
            this.Title = Title;
            this.ISBN = ISBN;
            this.Author = Author;
            AddToCatalog(this);
        }

        public virtual void addBook()
        {
            Console.WriteLine("This is AddBook function");
        }

        public virtual void removeBook()
        {
            Console.WriteLine("This is RemoveBook function");
        }

        private static void AddToCatalog(Book book)
        {
            Array.Resize(ref catalog, catalog.Length + 1);
            catalog[catalog.Length - 1] = book;
        }

        public static void ViewCatalogByGenre(Genre genre)
        {
            var booksByGenre = Array.FindAll(catalog, book => book.Type == genre);
            if (booksByGenre.Length == 0)
            {
                Console.WriteLine($"There are no books in the catalog for the genre: {genre}");
            }
            else
            {
                Console.WriteLine($"Books in the {genre} genre:");
                foreach (var book in booksByGenre)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                }
            }
        }
    }
}
