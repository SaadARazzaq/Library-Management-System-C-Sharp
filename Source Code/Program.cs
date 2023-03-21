using Library_Management_System_Using_C_Sharp;
using System;

namespace LibrarySystem
{

    class Program
    {
        static void Main(string[] args)
        {
            
            int choice = 0;
            string a = "", b = "", c = "";
            Library library = new Library(a, b, c);
            while (choice != 7)
            {
                while (true) // Loop will run until the input (i.e. in the form of int) is taken correctly
                {

                    try
                    {
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Enter what option you want to go with: ");
                        Console.WriteLine("1. Add Book(s) in library.");
                        Console.WriteLine("2. Search for a Book in library.");
                        Console.WriteLine("3. Remove a Book from library.");
                        Console.WriteLine("4. Filter Books by Author Name.");
                        Console.WriteLine("5. Filter Books issued to students.");
                        Console.WriteLine("6. Display Books in library.");
                        Console.WriteLine("7. Exit the library.");
                        Console.WriteLine();
                        Console.Write("\n-> Enter Your Choice: "); 
                        choice = int.Parse(Console.ReadLine()); // Asks for input, if it is in string or symbol, it will catch the exception
                        Console.WriteLine("\n----------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (choice < 1 && choice > 7)
                        {
                            continue; // If input is not in range (1 - 6), then it will go to while loop [at line 18] and run loop again asking to enter the number again
                        }
                        else if (choice >= 1 && choice <= 7)
                        {
                            break; // If the input is all correct and is in range (1 - 6), then it will come outside the loop and store the integer value in choice variable.
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                switch (choice)
                {

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        library.addBook();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        library.searchBook();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        library.removeBook();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\t --Filter Books by Author.--\n");
                        int choice1;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Do You want to: ");
                                Console.WriteLine("1. Submit Book");
                                Console.WriteLine("2. Withdraw Book");
                                Console.WriteLine("-> Enter Choice");
                                choice1 = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        switch (choice1)
                        {
                            case 1:
                                string name = "";
                                Author author = new Author(name);
                                string titleName, authorName, isbn;
                                Console.WriteLine("Enter title of book: ");
                                titleName = Console.ReadLine();
                                Console.WriteLine("Enter author of book: ");
                                authorName = Console.ReadLine();
                                Console.WriteLine("Enter isbn of book: ");
                                isbn = Console.ReadLine();
                                author.SubmitBook(titleName,authorName,isbn);
                                break;
                            case 2:
                                string name1 = "";
                                Author author1 = new Author(name1);
                                Console.WriteLine("Enter Book Title: ");
                                string title = Console.ReadLine();
                                author1.WithdrawBook(title);
                                break;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\t --Filter Books by Students.--\n");
                        int choice2;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Do You want to: ");
                                Console.WriteLine("1. Acquire Book");
                                Console.WriteLine("2. Return Book");
                                Console.WriteLine("-> Enter Choice");
                                choice2 = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch(Exception e) {
                                Console.WriteLine(e.Message);
                            }
                        }
                        switch (choice2)
                        {
                            case 1:
                                string name = ""; int id = 0;
                                Student student = new Student(name, id);
                                student.acquireBook();
                                break;
                            case 2:
                                string name1 = ""; int id1 = 0;
                                Student student1 = new Student(name1, id1);
                                student1.returnBook();
                                break;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        library.viewBooks();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 7:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\t --Exit the library.--\n");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nSome Error Occured... Try Again....");
                        break;
                }
            }
        }
    }
}
