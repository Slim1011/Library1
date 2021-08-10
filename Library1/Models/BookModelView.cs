using Library1.Models;
using System.Collections.Generic;

namespace Library1.Service
{
    public class BookModelView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public ICollection<AuthorModel> Authors { get; set; }
        public ICollection<CategoryModel> Categories { get; set; }
    }

    public class BookModelWithAuthorAndCategoryView
    {
        public int Id { get; set; }
        public string Title { get; set; }

       //public List<AuthorView> AuthorNames { get; set; }
       // public List<CategoryView> CategoryNames { get; set; }
        public List<string> AuthorNames { get; set; }
        public List<string> CategoryNames { get; set; }
    }
    //public class AuthorView
    //{

    //    public string Author { get; set; }
    //}
    //public class CategoryView
    //{

    //    public string Category { get; set; }
    //}
}