/*
Name: Melnikov, Dmitre
COP2360 - A4
Sept 9, 2024
Collaboration Statement: I worked on this alone; 
*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace melnikovD_A4
{
    internal class LibraryManagementSystem
    {
        // List to store books in the library; should csv file be used?
        private readonly List<Book> _books = new List<Book>();

        // Method to add a book to the catalog
        private void AddBook(string title, string author)
        {
            var book = new Book(title, author);
            _books.Add(book);
            Console.WriteLine($"'{title}' added to the catalog.");
        }

        // Method to check out a book by title
        private void CheckOutBook(string title)
        {
            var book = _books.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                book.CheckOut();
            }
            else
            {
                Console.WriteLine($"'{title}' not found in the catalog.");
            }
        }

        // Method to check in a book by title
        private void CheckInBook(string title)
        {
            var book = _books.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                book.CheckIn();
            }
            else
            {
                Console.WriteLine($"'{title}' not found in the catalog.");
            }
        }

        // Method to display all books in the catalog... for testing purposes.
        private void DisplayAllBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("No books in the catalog.");
                return;
            }

            Console.WriteLine("Books in the catalog:");
            foreach (var book in _books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Checked Out: {book.IsCheckedOut}");
            }
        }

        // Main method to provide a menu system for the library management
        public static void Main(string[] args)
        {
            var system = new LibraryManagementSystem();
            while (true)
            {
                // Display menu options
                Console.WriteLine("Welcome to the Library");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Check Out Book");
                Console.WriteLine("3. Check In Book");
                // Left this in for testing purposes.1
                Console.WriteLine("4. Display All Books");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                // Menu selection using switch statement.
                switch (option)
                {
                    case "1":
                        Console.Write("Enter book title: ");
                        var title = Console.ReadLine();
                        Console.Write("Enter book author: ");
                        var author = Console.ReadLine();
                        system.AddBook(title, author);
                        break;
                    case "2":
                        Console.Write("Enter book title to check it out: ");
                        title = Console.ReadLine();
                        system.CheckOutBook(title);
                        break;
                    case "3":
                        Console.Write("Enter book title to check in: ");
                        title = Console.ReadLine();
                        system.CheckInBook(title);
                        break;
                    case "4":
                        system.DisplayAllBooks();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // Book class to represent a book in the library.
        private class Book
        {
            // Parts of the Book class
            public string Title { get; private set; }
            public string Author { get; private set; }
            public bool IsCheckedOut { get; private set; }

            // Constructor to initialize a new instance of a book
            public Book(string title, string author)
            {
                Title = title;
                Author = author;
                IsCheckedOut = false;
            }

            // Method for checking out a book
            public void CheckOut()
            {
                if (!IsCheckedOut)
                {
                    IsCheckedOut = true;
                    Console.WriteLine($"'{Title}' checked out successfully.");
                }
                else
                {
                    Console.WriteLine($"'{Title}' is already checked out.");
                }
            }

            // Method for checking a book
            public void CheckIn()
            {
                if (IsCheckedOut)
                {
                    IsCheckedOut = false;
                    Console.WriteLine($"'{Title}' checked in successfully.");
                }
                else
                {
                    Console.WriteLine($"'{Title}' is already checked in.");
                }
            }
        }
    }
} 