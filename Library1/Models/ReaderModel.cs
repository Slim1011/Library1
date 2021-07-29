using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library.Models
{
    public class ReaderModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$")]
        public string Email { get; set; }
        public  ICollection<BookModel> Books { get; set; }

    }
}
