using Library.Data.DbContext;
using Library.Models;
using Library1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Service
{
    public class ReaderService : IReaderService
    {
        private LibraryDbContext _libraryDbContext;

        public ReaderService(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public ReaderWithBooksModel GetReaderWithBookById (int readerId)
        {
            var readerWithBooks = _libraryDbContext.Readers.Where(n => n.Id == readerId)
                .Select(reader => new ReaderWithBooksModel()
                {
                    Id = reader.Id,
                    Name = reader.Name,
                    Phone = reader.Phone,
                    Email = reader.Email,
                    Books = reader.Books.Select(n => new BookAuthorCategoryVM()
                    {
                        BookId = n.Id,
                        BookName = n.Title,
                        BookAuthors = n.Books_AuthorsModel.Select(n => n.AuthorModel.Author).ToList(),
                        BookCategories = n.Books_CategoriesModel.Select(n => n.CategoryModel.Category).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return readerWithBooks;
        }

    }

}
