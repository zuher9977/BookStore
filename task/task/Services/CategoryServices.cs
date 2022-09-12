using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;
using task.Models;

namespace task.Services
{
    public class CategoryServices:ICategoryServices
    {
        BContext context;
        public CategoryServices(BContext _context)
        {
            context = _context;
        }

        public List<Category> GetCategories()
        {
            List<Category> li = context.Categories.ToList();
            return li;
        }

        public void addCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public Category GetCategorybyId(int categoryId)
        {
            Category category = context.Categories.Where(i => i.Id == categoryId).First();
            return category;
        }
        public void update(Category category)
        {
            context.Categories.Attach(category);
            context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void delete(int id)
        {
            Category category = context.Categories.Where(e => e.Id == id).First();
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
