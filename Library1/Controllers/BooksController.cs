﻿using AutoMapper;
using Library.Data.DbContext;
using Library.Models;
using Library1.Interface;
using Library1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService _bookService;
        private LibraryDbContext _booksDbContext ;
        private readonly IMapper _mapper;

        public BooksController(LibraryDbContext booksDbContext, IMapper mapper, IBooksService bookService)
        {
            _bookService = bookService;
            _booksDbContext = booksDbContext;
            _mapper = mapper;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookService.NewGetBooksWithAuthorAndCategory();
            
            if (books.Count == 0)
            {
                throw new ClientException("No records found");
            }
            return Ok(books);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
           
            var book = _bookService.NewGetBookByIdWithAuthorAndCategory(id);

            if (book == null)
            {
                throw new ClientException("No records found against this id");
               

            }
            
            return Ok(book);
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
                throw new ClientException("No records found agains this id");
            }
            book.Title = bookModel.Title;

           
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
                throw new ClientException("Book not found");
            }
            _booksDbContext.Books.Remove(book);
            _booksDbContext.SaveChanges();
            return Ok("Book deleted successfully");
        }
    }
}
