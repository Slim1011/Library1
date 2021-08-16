using Library.Data.DbContext;
using Library1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private LibraryDbContext _categoryDbContext;
        public CategoriesController(LibraryDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;


        }
        // GET: api/<CategoriesController>


        // POST api/<CategoriesController>
        [HttpPost]
        public void PostCategory([FromBody] CategoryModel categoryModel)
        {
            _categoryDbContext.Categories.Add(categoryModel);
            _categoryDbContext.SaveChanges();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, [FromBody] CategoryModel categoryModel)
        {
            var category = _categoryDbContext.Categories.Find(id);
            if (category == null)
            {
                throw new ClientException("No records found agains this id");
            }
            category.Category = categoryModel.Category;
            _categoryDbContext.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryDbContext.Categories.Find(id);
            if (category == null)
            {
                throw new ClientException("No records found agains this id");
            }
            _categoryDbContext.Categories.Remove(category);
            _categoryDbContext.SaveChanges();
            return Ok("Category deleted successfully");

        }
    }
}
