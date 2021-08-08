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
        

        public ICollection<Book_CategoryModel> Books_CategoriesModel {  get  ; set; }
        public ICollection<Book_AuthorModel> Books_AuthorsModel { get; set; }
        //public ICollection<AuthorModel> Authors { get; set; }
        //public ICollection<CategoryModel> Categories { get; set; }
    }

    
}
