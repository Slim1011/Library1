using AutoMapper;
using Library.Models;
using Library1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Service
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookModel, BookModelWithAuthorAndCategoryView>()
                .ForMember(dto => dto.AuthorNames, opt => opt.MapFrom(x => x.Authors.Select(a => a.Author.Author)))
                .ForMember(dto => dto.CategoryNames, opt => opt.MapFrom(x => x.Categories.Select(a => a.Category.Category)));

            CreateMap<ReaderModel, ReaderWithBooksModel>()
                .ForMember(dto => dto.Books, opt => opt.MapFrom(x => x.Books.Select(b => new BookAuthorCategoryVM() 
                { 
                    BookId = b.Id,
                    BookName = b.Title,
                    BookAuthors = b.Authors.Select(x => x.Author.Author).ToList(),
                    BookCategories = b.Categories.Select(x => x.Category.Category).ToList(),
                })));
          
        }
    }

}
