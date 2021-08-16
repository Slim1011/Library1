using Library.Data.DbContext;
using Library.Models;
using Library1.Interface;
using Library1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private LibraryDbContext _readersDbContext;
        private IReadersService _readerService;
        public ReadersController(LibraryDbContext readersDbContext, IReadersService readerservice)
        {
            _readersDbContext = readersDbContext;
            _readerService = readerservice;
        }
        // GET: api/<ReaderController>
        [HttpGet]

        public IActionResult GetReaders()
        {
            var readers = _readerService.GetReardersWithBooksNew();
            if (readers == null)
            {
                throw new ClientException("No records found");
            }
            return Ok(readers);
        }


        // GET api/<ReaderController>/5
        [HttpGet("{id}")]
        public IActionResult GetReaderById(int id)
        {
            var reader = _readerService.GetRearderWithBooksByIdNew(id);
            if (reader == null)
            {
                throw new ClientException("No records found agains this id");
            }
            return Ok(reader);
        }

        // POST api/<ReaderController>
        [HttpPost]
        public void PostReader([FromBody] ReaderModel readerModel)
        {
            _readersDbContext.Readers.Add(readerModel);
            _readersDbContext.SaveChanges();

        }

        // PUT api/<ReaderController>/5
        [HttpPut("{id}")]
        public IActionResult PutReader(int id, ReaderModel readerModel)
        {
            var reader = _readersDbContext.Readers.Find(id);
            if (reader == null)
            {
                throw new ClientException("No records found agains this id");
            }
            reader.Name = readerModel.Name;
            reader.Phone = readerModel.Phone;
            reader.Email = readerModel.Email;
            _readersDbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<ReaderController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReader(int id)
        {
            var reader = _readersDbContext.Readers.Find(id);
            if (reader == null)
            {
                throw new ClientException("Reader not found");
            }
            _readersDbContext.Readers.Remove(reader);
            _readersDbContext.SaveChanges();
            return Ok("Reader deleted successfully");
        }
    }
}
