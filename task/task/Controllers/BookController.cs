using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using task.Data;
using task.Models;
using task.Services;

namespace task.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        IConfiguration configuration;
        IBookServices bookServices;
        IAuthorServices authorServices;
        ICategoryServices categoryServices;

        public BookController(IBookServices _bookServices,IAuthorServices _authorServices,ICategoryServices _categoryServices, IConfiguration _configuration)
        {
            bookServices = _bookServices;
            authorServices = _authorServices;
            categoryServices = _categoryServices;
            configuration = _configuration;
        }
        public IActionResult Index()
        {
            vmBook vm = new vmBook();
            List<Book> books = bookServices.GetBooks();
            vm.libook = books;
            List<Author> authors = authorServices.GetAuthors();
            vm.liauthor = authors;
            List<Category> categories = categoryServices.GetCategories();
            vm.licategory = categories;
            return View(vm);
        }
        public IActionResult addBook(vmBook vm)
        {

            string ImgName = Guid.NewGuid().ToString() + "." + vm.book.Image.FileName.Split('.')[1]; 
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["foldername"], ImgName);
            vm.book.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            vm.book.ImgPath = ImgName; 


            bookServices.addBook(vm.book);
            List<Book> books = bookServices.GetBooks();
            vm.libook = books;
            List<Author> authors = authorServices.GetAuthors();
            vm.liauthor = authors;
            List<Category> categories = categoryServices.GetCategories();
            vm.licategory = categories;
            return View("Index",vm);
        }
        public IActionResult Edit(int id)
        {
            Book book= bookServices.GetBookbyId(id);
            return Json(book);
        }
        public IActionResult editBook(vmBook vm)
        {
            string ImgName = Guid.NewGuid().ToString() + "." + vm.book.Image.FileName.Split('.')[1]; 
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["foldername"], ImgName);
            vm.book.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            vm.book.ImgPath = ImgName; 


            bookServices.update(vm.book);
            List<Book> books = bookServices.GetBooks();
            vm.libook = books;
            List<Author> authors = authorServices.GetAuthors();
            vm.liauthor = authors;
            List<Category> categories = categoryServices.GetCategories();
            vm.licategory = categories;
            return View("Index", vm);
        }
        public IActionResult delete(int id)
        {
            bookServices.delete(id);
            vmBook vm = new vmBook();
            List<Book> books = bookServices.GetBooks();
            vm.libook = books;
            List<Author> authors = authorServices.GetAuthors();
            vm.liauthor = authors;
            List<Category> categories = categoryServices.GetCategories();
            vm.licategory = categories;
            return View("Index", vm);
        }
    }
}
