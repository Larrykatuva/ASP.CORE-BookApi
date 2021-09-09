using API_book.Data.Services;
using API_book.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _booksService;

        public BooksController(IBookService bookService)
        {
            this._booksService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            this._booksService.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = this._booksService.GetAllBooks();
            return Ok(allBooks);
        }


        [HttpGet("get-book-by-id/{Id}")]
        public IActionResult GetBookById(int Id)
        {
            var book = this._booksService.GetBookById(Id);
            return Ok(book);
        }

        [HttpPut("update-book-by_id/{id}")]
        public IActionResult UpdateBookById(int id, BookVM book)
        {
            var updateBook = this._booksService.UpdateBookById(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by_id")]
        public IActionResult DeleteBookById(int bookId)
        {
            this._booksService.DeleteBookById(bookId);
            return Ok();
        }

    }
}
