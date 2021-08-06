using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Models
{
    public class Book_AuthorModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public BookModel BookModel { get; set; }

        public int AuthorId { get; set; }
        public AuthorModel AuthorModel { get; set; }
    }
}
