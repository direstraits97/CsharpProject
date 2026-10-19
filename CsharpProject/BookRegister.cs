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

        public void addBook(string title, string author, string genre, int year)
        {
            Book book = new Book();
            book.Title = title;
            book.Author = author;
            book.Genre = genre;
            book.Year = year;

            books.Add(book);
            storage.Save(books);
        }

        public void delBook(int index)
        {
            books.RemoveAt(index);
            storage.Save(books);
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }
}
