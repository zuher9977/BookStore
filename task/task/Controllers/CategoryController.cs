using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data;
using task.Models;
using task.Services;

namespace task.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ICategoryServices categoryServices;
        public CategoryController(ICategoryServices _categoryServices)
        {
            categoryServices = _categoryServices;
        }
        public IActionResult Index()
        {
            List<Category> li = categoryServices.GetCategories();
            vmCategory vm = new vmCategory();
            vm.Listcategories = li;
            return View(vm);
        }

        public IActionResult addCategory(vmCategory vm)
        {
            
            categoryServices.addCategory(vm.categories);
            List<Category> li = categoryServices.GetCategories();
            vm.Listcategories = li;
            return View("Index", vm);
        }

        public IActionResult Edit(int id)
        {
            Category category = categoryServices.GetCategorybyId(id);
            return Json(category);
        }

        public IActionResult editCategory(vmCategory vm)
        {
            categoryServices.update(vm.categories);
            List<Category> li = categoryServices.GetCategories();
            vm.Listcategories = li;
            return View("Index", vm);
        }

        public IActionResult delete(int id)
        {
            categoryServices.delete(id);
            List<Category> li = categoryServices.GetCategories();
            vmCategory vm = new vmCategory();
            vm.Listcategories = li;
            return View("Index",vm);
        }
    }
}
