﻿using Library.Data.DbContext;
using Library1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Interface
{
    public interface IBooksService
    {
        BookModelWithAuthorAndCategoryView GetBookByIdWithAuthorAndCategory(int bookId);
        List<BookModelWithAuthorAndCategoryView> GetBooksWithAuthorAndCategory();
        List<BookModelWithAuthorAndCategoryView> NewGetBooksWithAuthorAndCategory();
        BookModelWithAuthorAndCategoryView NewGetBookByIdWithAuthorAndCategory(int bookId);

    }
}
