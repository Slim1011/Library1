using AutoMapper;
using Library.Data.DbContext;
using Library1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private LibraryDbContext _authorDbContext;
        private IMapper _mapper;
        public AuthorsController(LibraryDbContext authorDbContext, IMapper mapper)
        {
            _authorDbContext = authorDbContext;
            _mapper = mapper;
        }
        // GET: api/<AuthorsController>


        // POST api/<AuthorsController>
        [HttpPost]
        public void PostAuthor([FromBody] AuthorModel authorModel)
        {
            _authorDbContext.Authors.Add(authorModel);
            _authorDbContext.SaveChanges();
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, [FromBody] AuthorModel authorModel)
        {
            var author = _authorDbContext.Authors.Find(id);
            if (author == null)
            {
                throw new ClientException("No records found agains this id");
            }
            author.Author = authorModel.Author;

            _authorDbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _authorDbContext.Authors.Find(id);
            if (author == null)
            {
                throw new ClientException("Author not found");
            }
            _authorDbContext.Authors.Remove(author);
            _authorDbContext.SaveChanges();
            return Ok("Author deleted successfully");
        }
    }
}
