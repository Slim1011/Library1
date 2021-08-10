using General.Models;
using Library.Models;
using Library1.Models;
using Library1.Service;
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

        public LibraryDbContext()
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_CategoryModel>()
                .HasOne(b => b.BookModel)
                .WithMany(bc => bc.Books_CategoriesModel)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_CategoryModel>()
                .HasOne(c => c.CategoryModel)
                .WithMany(bc => bc.Books_CategoriesModel)
                .HasForeignKey(ci => ci.CategoryId);


            modelBuilder.Entity<Book_AuthorModel>()
               .HasOne(b => b.BookModel)
               .WithMany(ba => ba.Books_AuthorsModel)
               .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_AuthorModel>()
               .HasOne(a => a.AuthorModel)
               .WithMany(ba => ba.Books_AuthorsModel)
               .HasForeignKey(ai => ai.AuthorId);
        }

      

        public DbSet<BookModel> Books { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<Book_CategoryModel> Books_Categories { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<Book_AuthorModel> Books_Authors { get; set; }
        public DbSet<ReaderModel> Readers { get; set; }
      // public DbSet<BookModelWithAuthorAndCategoryView> BookModelWithAuthorAndCategory { get; set; }
    }
}
