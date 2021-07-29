using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.DbContext
{
    public class LibraryDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<ReaderModel> Readers { get; set; }
    }
}
