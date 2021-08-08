using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Data.DbContext;
using AutoMapper;
using Library1.Service;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
       private LibraryDbContext _booksDbContext ;
        private readonly IMapper _mapper;

        public BooksController(LibraryDbContext booksDbContext, IMapper mapper)
        {
            _booksDbContext = booksDbContext;
            _mapper = mapper;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _booksDbContext.Books.ToList();
            //var bookModels = _mapper.Map<BookModelView>(books);
            if (books.Count == 0)
            {
                return NotFound("No records found");
            }
            return Ok(books);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {

            
            var book = _booksDbContext.Books.FirstOrDefault(b => b.Id == id);
            var bookModel = _mapper.Map<BookModelView>(book);
            if (bookModel == null)
            {
                return NotFound("No records found agains this id");
            }
            return Ok(bookModel);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void PostBook([FromBody] BookModel BookModel)
        {
            _booksDbContext.Books.Add(BookModel);
            _booksDbContext.SaveChanges();

        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, [FromBody] BookModel bookModel)
        {
           var book = _booksDbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound("No records found agains this id");
            }
            book.Title = bookModel.Title;

            //book.Author = bookModel.Author;
            //book.Category = bookModel.Category;
            _booksDbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _booksDbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound("Book not found");
            }
            _booksDbContext.Books.Remove(book);
            _booksDbContext.SaveChanges();
            return Ok("Book deleted successfully");
        }
    }
}
