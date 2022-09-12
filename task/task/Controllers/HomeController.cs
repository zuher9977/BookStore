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
    public class HomeController : Controller
    {
        IAuthorServices authorServices;
        IBookServices bookServices;
        ICategoryServices categoryServices;
        IAccountServices accountServices;
        public HomeController(IAuthorServices _authorServices, IBookServices _bookServices, ICategoryServices _categoryServices,IAccountServices _accountServices)
        {
            authorServices = _authorServices;
            bookServices = _bookServices;
            categoryServices = _categoryServices;
            accountServices = _accountServices;
        }
        public IActionResult Index()
        {
            vmHome vm = new vmHome();
            List<Book> books = bookServices.GetBooks();
            List<Author> authors = authorServices.GetAuthors();
            List<Category> categories = categoryServices.GetCategories();

            vm.books = books;
            vm.authors = authors;
            vm.categories = categories;


            int bookCount = bookServices.bookcount();
            ViewData["bookCount"] = bookCount;
            int userCount = accountServices.usercount();
            ViewData["userCount"] = userCount;

            return View(vm);
        }

        public IActionResult search(vmHome vm)
        {
            int authorId = vm.author.Id;
            int categoryId = vm.category.Id;
            List<Book> books = bookServices.GetBooksByAuthCatId(authorId, categoryId);
            vm.books = books;

            List<Author> authors = authorServices.GetAuthors();
            List<Category> categories = categoryServices.GetCategories();
            vm.authors = authors;
            vm.categories = categories;

            int bookCount = bookServices.bookcount();
            ViewData["bookCount"] = bookCount;
            int userCount = accountServices.usercount();
            ViewData["userCount"] = userCount;
            return View("Index",vm);
        }
    }
}
