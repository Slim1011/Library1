using Library.Data.DbContext;
using Library.Models;
using Library1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library1.Interface
{
    public interface IReadersService
    {
       // ReaderWithBooksModel GetReaderWithBookById(int readerId);
         ReaderWithBooksModel GetRearderWithBooksByIdNew(int readerId);
        List<ReaderWithBooksModel> GetReardersWithBooksNew();

    }
}
