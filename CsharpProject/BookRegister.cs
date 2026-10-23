using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpProject
{
    public class BookRegister
    {
        private readonly IBookRegisterStorage storage;

        private List<Book> books;

        public BookRegister(IBookRegisterStorage storage)
        {
            this.storage = storage;
            books = storage.Load();
        }

        public void addBook(string title, string author, string genre, string year, string status)
        {
            Book book = new Book();
            book.Title = title;
            book.Author = author;
            book.Genre = genre;
            book.Year = year;
            book.Status = status;

            books.Add(book);
            storage.Save(books);
        }

        public void putBook(int index, string title, string author, string genre, string year, string status)
        {
            books[index].Title = title;
            books[index].Author = author;
            books[index].Genre = genre;
            books[index].Year = year;
            books[index].Status = status;
            storage.Save(books);
        }

        public void delBook(int index)
        {
            books.RemoveAt(index);
            storage.Save(books);
        }

        public void putStatusBook(int index, string status)
        {
            books[index].Status = status;
            storage.Save(books);
        }

        public void filterBook(string input)
        {
            List<Book> result = books.Where(book => book.Title.Contains(input, StringComparison.OrdinalIgnoreCase) || 
            book.Author.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (Book book in result)
            {
                {
                    Console.WriteLine($"{book.Title}\n Författare: {book.Author}\n Genre: {book.Genre}\n År: {book.Year}\n Lässtatus: {book.Status}\n");
                }
            }
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }
}
