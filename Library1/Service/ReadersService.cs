using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Library.Data.DbContext;
using Library.Models;
using Library1.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library1.Service
{
    public class ReadersService : IReadersService
    {
        private LibraryDbContext _libraryDbContext;
        private IMapper _mapper;

        public ReadersService(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        //public ReaderWithBooksModel GetReaderWithBookById (int readerId)
        //{
        //    var readerWithBooks = _libraryDbContext.Readers.Where(n => n.Id == readerId)
        //        .Select(reader => new ReaderWithBooksModel()
        //        {
        //            Id = reader.Id,
        //            Name = reader.Name,
        //            Phone = reader.Phone,
        //            Email = reader.Email,
        //            Books = reader.Books.Select(n => new BookAuthorCategoryVM()
        //            {
        //                BookId = n.Id,
        //                BookName = n.Title,
        //                BookAuthors = n.Authors.Select(n => n.Author.Author).ToList(),
        //                BookCategories = n.Categories.Select(n => n.Category.Category).ToList()
        //            }).ToList()
        //        }).FirstOrDefault();
        //    return readerWithBooks;
        //}
        public ReaderWithBooksModel GetRearderWithBooksByIdNew(int readerId)
        {
            var readerWithBooks = _libraryDbContext.Readers.Where(n => n.Id == readerId).Include(b => b.Books).ThenInclude(b => b.Authors)
                .ThenInclude(a => a.Author).Include(c => c.Books).ThenInclude(c => c.Categories).ThenInclude(c => c.Category).FirstOrDefault();

            return _mapper.Map<ReaderWithBooksModel>(readerWithBooks);
        }

        public List<ReaderWithBooksModel> GetReardersWithBooksNew()
        {
            var readersWithBooks = _libraryDbContext.Readers.Include(b => b.Books).ThenInclude(b => b.Authors).ThenInclude(a => a.Author)
                .Include(c => c.Books).ThenInclude(c => c.Categories).ThenInclude(c => c.Category).ToList();

            return _mapper.Map<List<ReaderWithBooksModel>>(readersWithBooks);

        }

    }

}
