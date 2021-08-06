using AutoMapper;
using Library.Models;
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
            CreateMap<BookModel, BookModelView>();
                //.ForMember(src => )
                //;
        }
    }
}
