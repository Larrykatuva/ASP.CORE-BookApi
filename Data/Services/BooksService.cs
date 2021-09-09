using API_book.Data.Models;
using API_book.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_book.Data.Services
{
    public class BooksService : IBookService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBook(BookVM book)
        {
            var _book =  new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };

            await _context.Books.AddAsync(_book);

            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks() {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetBookById(int bookId) => await _context.Books.FirstOrDefaultAsync(n => n.Id == bookId);

        public async Task<Book> UpdateBookById(int bookId, BookVM book)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                await _context.SaveChangesAsync();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = this._context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                this._context.Books.Remove(_book);
                this._context.SaveChanges();
            }
        }


        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        Task<Book> IBookService.GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        Task<Book> IBookService.UpdateBookById(int bookId, BookVM book)
        {
            throw new NotImplementedException();
        }
    }
}
