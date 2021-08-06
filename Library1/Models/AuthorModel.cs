using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Models
{
    public class AuthorModel
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public List<Book_AuthorModel> Books_AuthorsModel { get; set; }
    }
}
