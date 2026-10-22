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

        public void addBook(string title, string author, string genre, int year, string status)
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

        public void putBook(int index, string title, string author, string genre, int year, string status)
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

        public List<Book> GetBooks()
        {
            return books;
        }
    }
}
