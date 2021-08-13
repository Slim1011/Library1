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
                .ForMember(dto => dto.AuthorNames, opt => opt.MapFrom(x => x.Books_AuthorsModel.Select(a => a.AuthorModel.Author)))
                .ForMember(dto => dto.CategoryNames, opt => opt.MapFrom(x => x.Books_CategoriesModel.Select(a => a.CategoryModel.Category)));
        }
    }

}
