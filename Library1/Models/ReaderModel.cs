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
        [Key]
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

    public class ReaderWithBooksModel 
    {
         [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$")]
        public string Email { get; set; }
        public List<BookAuthorCategoryVM> Books { get; set; }

        //public List<string> BookAuthors { get; set; }
        //public List<string> BookCategories { get; set; }

    }
    public class BookAuthorCategoryVM
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
        public List<string> BookCategories { get; set; }
    }
}
