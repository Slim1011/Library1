using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Library.Data.DbContext;
using Library1.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library1.Service
{
    public class BooksService : IBooksService
    {
        private LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public BooksService(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }


        public BookModelWithAuthorAndCategoryView GetBookByIdWithAuthorAndCategory(int bookId)
        {
            var bookWithAuthorsAndCategories = _libraryDbContext.Books.Where(n => n.Id == bookId).Select(book => new BookModelWithAuthorAndCategoryView()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorNames = book.Authors.Select(n => n.Author.Author).ToList(),
                CategoryNames = book.Categories.Select(n => n.Category.Category).ToList()

            }).FirstOrDefault();
            return bookWithAuthorsAndCategories;
        }

        public List<BookModelWithAuthorAndCategoryView> GetBooksWithAuthorAndCategory()
        {

            var result = new List<BookModelWithAuthorAndCategoryView>();
            foreach (var id in _libraryDbContext.Books.Select(book => book.Id).ToList())
            {
                result.Add(GetBookByIdWithAuthorAndCategory(id));

            }

            return result;


        }

        public BookModelWithAuthorAndCategoryView NewGetBookByIdWithAuthorAndCategory(int bookId)

        {
            var bookWithAuthorsAndCategories = _libraryDbContext.Books.Where(n => n.Id == bookId).Include(b => b.Authors).ThenInclude(a => a.Author).Include(b => b.Categories).ThenInclude(a => a.Category).FirstOrDefault();

            return _mapper.Map<BookModelWithAuthorAndCategoryView>(bookWithAuthorsAndCategories);
        }

        public List<BookModelWithAuthorAndCategoryView> NewGetBooksWithAuthorAndCategory()
        {
            var result = _libraryDbContext.Books.Include(b => b.Authors).ThenInclude(a => a.Author).Include(b => b.Categories).ThenInclude(a => a.Category).ToList();

            return _mapper.Map<List<BookModelWithAuthorAndCategoryView>>(result)
                3445345
                dfsdfsdfsd


        }
    }

}
