using Library_Management_System_Using_C_Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_Using_C_Sharp
{
    public class Author
    {
        private string name;
        private Book[] availableBooks = new Book[0];

        public Author(string name)
        {
            this.name = name;
        }

        public void SubmitBook(string title, string author, string isbn)
        {
            Book book = new Book(title, author, isbn);
            if (availableBooks.Length < 100)
            {
                Array.Resize(ref availableBooks, availableBooks.Length + 1);
                availableBooks[availableBooks.Length - 1] = book;
                Console.WriteLine("The book '{0}' has been submitted.", book.Title);
            }
            else
            {
                Console.WriteLine("The library is full and cannot accept more books.");
            }
        }

        public void WithdrawBook(string title)
        {
            Book book = FindBook(title);
            if (book != null)
            {
                Array.Resize(ref availableBooks, availableBooks.Length - 1);
                Console.WriteLine("The book '{0}' has been withdrawn.", book.Title);
            }
            else
            {
                Console.WriteLine("The book '{0}' was not found.", title);
            }
        }

        private Book FindBook(string title)
        {
            foreach (Book book in availableBooks)
            {
                if (book.Title.ToLower() == title.ToLower())
                {
                    return book;
                }
            }
            return null;
        }
    }

}
