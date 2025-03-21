using LibrarySystem;
using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    class Book
    {
        public string title;
        public string author;
        public string ISBN;
        public bool avilability;

        public Book(string title, string author, string ISBN, bool avilability = true)
        {
            this.title = title;
            this.author = author;
            this.ISBN = ISBN;
            this.avilability = avilability;
        }

        public string BookTitle
        {
            get { return title; }
            set { title = value; }
        }
        public string BookAuthor
        {
            get { return author; }
            set { author = value; }
        }
        public string BookISBN
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
        public bool BookAvilability
        {
            get { return avilability; }
            set { avilability = value; }
        }
    }

    class Library
    {
        List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.BookTitle}' by {book.BookAuthor} added to the library.");
        }

        public Book SearchBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                var book = books[i];
                if (book.BookTitle == title)
                {
                    Console.WriteLine($"Found '{book.BookTitle}' by {book.BookAuthor}. Available: {book.BookAvilability}");
                    return book;
                }
            }
            Console.WriteLine($"Sorry, '{title}' not found in the library.");
            return null;
        }

        public Book BorrowBook(string borrowBook)
        {
            var book = SearchBook(borrowBook);
            if (book != null && book.BookAvilability)
            {
                book.BookAvilability = false;
                Console.WriteLine($"You have borrowed '{book.BookTitle}' by {book.BookAuthor}.");
                return book;
            }
            Console.WriteLine($"Sorry, '{borrowBook}' is either not available or not found in the library.");
            return null;
        }


        public Book ReturnBook(string returnBook)
        {
            var book = SearchBook(returnBook);
            if (book != null && !book.BookAvilability)
            {
                book.BookAvilability = true;
                Console.WriteLine($"You have successfully returned '{book.BookTitle}' by {book.BookAuthor}.");
                return book;
            }
            Console.WriteLine($"Sorry, '{returnBook}' was not borrowed or not found in the library.");
            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            Console.WriteLine("Searching and borrowing books...");
            library.SearchBook("The Great Gatsby");
            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter");

            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter");

            Console.ReadLine();
        }
    }
}
