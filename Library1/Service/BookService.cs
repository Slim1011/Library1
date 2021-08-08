using Library.Data.DbContext;
using Library.Models;
using Library1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Service
{
    public class BookService
    {
        private LibraryDbContext _libraryDbContext;
        public BookService(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        //public BookModelView GetBookById(int id)
        //{
        //    var bookWithAuthors = _libraryDbContext.Books.Where(n => n.Id == id).Select(BookModel => new BookModelView()
        //    {
        //        Title = book.Title;
        //    Authors = 

        //    }
        //}
       

    }
   
}
