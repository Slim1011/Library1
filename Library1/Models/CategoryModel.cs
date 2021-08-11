using Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public ICollection<Book_CategoryModel> Books_CategoriesModel { get; set; }

       
    }
    
}
