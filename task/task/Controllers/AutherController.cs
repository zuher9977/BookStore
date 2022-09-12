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
    public class AutherController : Controller
    {
        IConfiguration configuration;
        IAuthorServices authorServices;
        INationalityServices nationalityServices;
        public AutherController(IAuthorServices _authorServices,INationalityServices _nationalityServices, IConfiguration _configuration)
        {
            authorServices = _authorServices;
            nationalityServices = _nationalityServices;
            configuration = _configuration;
        }
        public IActionResult Index()
        {
            List<Nationality> linat = nationalityServices.getNationalies();
            List<Author> li = authorServices.GetAuthors();
            vmAuthor vm = new vmAuthor();
            vm.liNationality = linat;
            vm.liAuther = li;
            return View(vm);
        }
        public IActionResult addAuhor(vmAuthor vm)
        {

            string ImgName = Guid.NewGuid().ToString() + "." + vm.auther.Image.FileName.Split('.')[1]; 
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["foldername"], ImgName);
            vm.auther.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            vm.auther.ImgPath = ImgName; 



            authorServices.AddNewAuthor(vm.auther);
            List<Nationality> linat = nationalityServices.getNationalies();
            List<Author> li = authorServices.GetAuthors();
            vm.liNationality = linat;
            vm.liAuther = li;
            return View("Index",vm);
        }
        public IActionResult Edit(int id)
        {
            Author author = authorServices.GetAuthorbyId(id);
            return Json(author);
        }
        public IActionResult editAuthor(vmAuthor vm)
        {
            if(vm.auther.ImgPath != null) { 
            string ImgName = Guid.NewGuid().ToString() + "." + vm.auther.Image.FileName.Split('.')[1];
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["foldername"], ImgName);
            vm.auther.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            vm.auther.ImgPath = ImgName;
            }

            authorServices.update(vm.auther);
            List<Nationality> linat = nationalityServices.getNationalies();
            List<Author> li = authorServices.GetAuthors();
            vm.liNationality = linat;
            vm.liAuther = li;
            return View("Index", vm);
        }
        public IActionResult delete(int id)
        {
            authorServices.delete(id);
            List<Nationality> linat = nationalityServices.getNationalies();
            List<Author> li = authorServices.GetAuthors();
            vmAuthor vm = new vmAuthor();
            vm.liNationality = linat;
            vm.liAuther = li;
            return View("Index",vm);
        }
    }
}
