using General.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Library.Data.DbContext
{
    public class LibraryDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var mySqlSettings = string.Format("server=10.10.0.4;uid=admin;pwd=Admin123;database=library;Charset=utf8mb4;Convert Zero Datetime=True");
            optionsBuilder.UseMySQL(mySqlSettings);
        }

        public LibraryDbContext(IOptions<MySqlConfigurationModel> config)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<ReaderModel> Readers { get; set; }
    }
}
