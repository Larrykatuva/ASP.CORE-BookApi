using API_book.Data.Models;
using API_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_book.Data.Services
{
    public interface IBookService
    {
        public Task<bool> AddBook(BookVM book);
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> GetBookById(int bookId);

        public Task<Book> UpdateBookById(int bookId, BookVM book);


        public void DeleteBookById(int bookId);

        public Task<bool> SaveChangesAsync();

    }
}
