using Library1.Models;
using System.Collections.Generic;

namespace Library1.Service
{
    internal class BookModelView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public ICollection<AuthorModel> Authors { get; set; }
        public ICollection<CategoryModel> Categories { get; set; }
    }
}