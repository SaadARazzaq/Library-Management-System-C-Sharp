using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_Using_C_Sharp
{
    public class Student
    {
        private string name;
        private int id;
        private Book[] borrowedBooks;

        public Student(string name, int id)
        {
            this.name = name;
            this.id = id;
            borrowedBooks = new Book[0];
        }

        public void acquireBook()
        {
            if (borrowedBooks.Count() < 3)
            {
                Book book = new Book("Book Title", "Author Name", "ISBN Number");
                Array.Resize(ref borrowedBooks, borrowedBooks.Length + 1);
                borrowedBooks[borrowedBooks.Length - 1] = book;
                Console.WriteLine("Student {0} has borrowed the book '{1}'.", name, book.Title);
            }
            else
            {
                Console.WriteLine("Student {0} cannot borrow more than 3 books at a time.", name);
            }
        }

        public void returnBook()
        {
            Console.WriteLine("Enter the title of the book to return:");
            string title = Console.ReadLine();

            int index = -1;
            for (int i = 0; i < borrowedBooks.Length; i++)
            {
                if (borrowedBooks[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Student {0} has not borrowed the book '{1}'.", name, title);
            }
            else
            {
                Book book = borrowedBooks[index];
                for (int i = index; i < borrowedBooks.Length - 1; i++)
                {
                    borrowedBooks[i] = borrowedBooks[i + 1];
                }
                Array.Resize(ref borrowedBooks, borrowedBooks.Length - 1);
                Console.WriteLine("Student {0} has returned the book '{1}'.", name, book.Title);
            }
        }
    }
}
