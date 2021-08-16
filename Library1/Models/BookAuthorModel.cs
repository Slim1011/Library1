using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Models
{
    public class BookAuthorModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public BookModel Book { get; set; }

        public int AuthorId { get; set; }
        public AuthorModel Author { get; set; }
    }
}
