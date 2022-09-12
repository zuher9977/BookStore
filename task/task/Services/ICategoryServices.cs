using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;

namespace task.Services
{
    public interface ICategoryServices
    {
        List<Category> GetCategories();
        void addCategory(Category category);
        Category GetCategorybyId(int categoryId);
        void update(Category category);
        void delete(int id);
    }
}
