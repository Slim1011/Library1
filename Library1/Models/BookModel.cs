using Library1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        

        public ICollection<BookCategoryModel> Categories {  get  ; set; }
        public ICollection<BookAuthorModel> Authors { get; set; }
       
    }

    
}
