﻿using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Models
{
    public class Book_CategoryModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public BookModel BookModel { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel CategoryModel { get; set; }
    }
}
