using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management_System_Using_C_Sharp
{
    public class Library : Book
    {
        public Library(string Title, string Author, string ISBN) : base(Title, Author, ISBN) { }
        public Book[] books;
        public override void addBook()
        {
            Console.WriteLine("\t---- Add Book(s) in library.----\n");
            int totalBooks;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter total number of books you want to add: ");
                    totalBooks = int.Parse(Console.ReadLine());
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            books = new Book[totalBooks]; // creating an array of Book objects to store information for multiple books
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine("-> Book {0}", i + 1);
                Console.WriteLine("Enter title of book {0}: ", i + 1);
                Title = Console.ReadLine();
                Console.WriteLine("Enter author of book {0}: ", i + 1);
                Author = Console.ReadLine();
                Console.WriteLine("Enter isbn of book: {0}", i + 1);
                ISBN = Console.ReadLine();
                books[i] = new Book(Title, Author, ISBN);
            }
        }
        public override void removeBook()
        {
            Console.WriteLine("\t---- Remove Book from library.----\n");
            Console.WriteLine("Enter title of the book you want to remove: ");
            Title = Console.ReadLine();

            if (books == null || books.Length == 0)
            {
                Console.WriteLine("The library is empty. There are no books to remove.");
                return;
            }

            bool bookFound = false;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Title.ToLower() == Title.ToLower())
                {
                    bookFound = true;
                    for (int j = i; j < books.Length - 1; j++)
                    {
                        books[j] = books[j + 1];
                    }
                    Array.Resize(ref books, books.Length - 1);
                    Console.WriteLine("Book with title '{0}' has been removed from the library.", Title);
                    break;
                }
            }

            if (!bookFound)
            {
                Console.WriteLine("Book with title '{0}' was not found in the library.", Title);
            }
        }

        public Book searchBook()
        {
            string searchTitle;
            Console.WriteLine("\t---- Search Book in library.----\n");
            Console.WriteLine("Enter title of the book you want to search: ");
            searchTitle = Console.ReadLine();

            if (books == null || books.Length == 0)
            {
                Console.WriteLine("The library is empty. There are no books to search.");
                return null;
            }

            foreach (Book book in books)
            {
                if (book.Title.ToLower() == searchTitle.ToLower())
                {
                    Console.WriteLine("Book with title '{0}' has been found in the library.", searchTitle);
                    return book;
                }
            }

            Console.WriteLine("Book with title '{0}' was not found in the library.", searchTitle);
            return null;
        }

        public void viewBooks()
        {
            Console.WriteLine("\t---- Display Books in library.----\n");
            if (books == null || books.Length == 0)
            {
                Console.WriteLine("The library is empty. There are no books to display.");
            }
            else
            {
                foreach (Book book in books)
                {
                    Console.WriteLine("Title {0}\t| Author {1}\t| ISBN {2}", book.Title, book.Author, book.ISBN);
                }
            }
        }
    }
}
