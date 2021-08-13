using AutoMapper;
using Library.Data.DbContext;
using Library.Models;
using Library1.Interface;
using Library1.Models;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Service
{
    public class BookService : IBookService
    {
        private LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public BookService(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        //public void AddBookWithAuthor(BookModelView bookModelView)
        //{
        //    var _book = new BookModel
        //    {
        //        Title = bookModelView.Title
        //    };
        //    _libraryDbContext.Books.Add(_book);
        //    _libraryDbContext.SaveChanges();

        //    foreach (var id in bookModelView.Authors)
        //    {
        //        var _book_author = new Book_AuthorModel()
        //        {
        //            BookId = bookModelView.Id,
        //            AuthorId = 
        //        };
        //        _libraryDbContext.Books_Authors.Add(_book_author);
        //        _libraryDbContext.SaveChanges();
        //    }
        //}
        public BookModelWithAuthorAndCategoryView GetBookByIdWithAuthorAndCategory(int bookId)
        {
            var _bookWithAuthorsAndCategories = _libraryDbContext.Books.Where(n => n.Id == bookId).Select(book => new BookModelWithAuthorAndCategoryView()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorNames = book.Books_AuthorsModel.Select(n => n.AuthorModel.Author).ToList(),
                CategoryNames = book.Books_CategoriesModel.Select(n => n.CategoryModel.Category).ToList()
                //AuthorNames = book.Books_AuthorsModel.Select(n => new AuthorView() {Author = n.AuthorModel.Author }).ToList(),
                //CategoryNames = book.Books_CategoriesModel.Select(n => new CategoryView() { Category = n.CategoryModel.Category }).ToList()
            }).FirstOrDefault();
            return _bookWithAuthorsAndCategories;
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
            var _bookWithAuthorsAndCategories = _libraryDbContext.Books.Where(n => n.Id == bookId).Include(b => b.Books_AuthorsModel).ThenInclude(a => a.AuthorModel).Include(b => b.Books_CategoriesModel).ThenInclude(a => a.CategoryModel).FirstOrDefault();
            return _mapper.Map<BookModelWithAuthorAndCategoryView>(_bookWithAuthorsAndCategories);
        }

        public List<BookModelWithAuthorAndCategoryView> NewGetBooksWithAuthorAndCategory()
        {
            var result = _libraryDbContext.Books.Include(b => b.Books_AuthorsModel).ThenInclude(a=>a.AuthorModel).Include(b => b.Books_CategoriesModel).ThenInclude(a => a.CategoryModel).ToList();
            return _mapper.Map<List<BookModelWithAuthorAndCategoryView>>(result);
        }
    }

}
