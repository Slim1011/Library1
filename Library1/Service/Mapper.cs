using AutoMapper;
using Library.Models;
using Library1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Service
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BookModel, BookModelView>()
                .ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.Books_AuthorsModel))
                .ForMember(dto => dto.Categories, opt => opt.MapFrom(x => x.Books_CategoriesModel)); 
           // CreateMap<AuthorModel, BookModelView>();
                
        }
    }
}
