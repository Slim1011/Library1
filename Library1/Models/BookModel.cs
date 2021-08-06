﻿using Library1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        

        public List<Book_CategoryModel> Books_CategoriesModel {  get  ; set; }
        public List<Book_AuthorModel> Books_AuthorsModel { get; set; }
    }

    
}
