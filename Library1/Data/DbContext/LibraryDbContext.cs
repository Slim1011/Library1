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
            modelBuilder.Entity<BookCategoryModel>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.Categories)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<BookCategoryModel>()
                .HasOne(c => c.Category)
                .WithMany(bc => bc.Books)
                .HasForeignKey(ci => ci.CategoryId);


            modelBuilder.Entity<BookAuthorModel>()
               .HasOne(b => b.Book)
               .WithMany(ba => ba.Authors)
               .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<BookAuthorModel>()
               .HasOne(a => a.Author)
               .WithMany(ba => ba.Books)
               .HasForeignKey(ai => ai.AuthorId);
        }

      

        public DbSet<BookModel> Books { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<BookCategoryModel> Books_Categories { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookAuthorModel> Books_Authors { get; set; }
        public DbSet<ReaderModel> Readers { get; set; }
      // public DbSet<BookModelWithAuthorAndCategoryView> BookModelWithAuthorAndCategory { get; set; }
    }
}
