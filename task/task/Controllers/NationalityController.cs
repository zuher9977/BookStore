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
    public class NationalityController : Controller
    {
        INationalityServices nationality;
        public NationalityController(INationalityServices _nationality)
        {
            nationality = _nationality;
        } 
        public IActionResult Index()
        {
            List<Nationality> li= nationality.getNationalies();
            vmNationality vm = new vmNationality();
            vm.ListNationalities = li;
            return View(vm);
        }
        public IActionResult AddNat(vmNationality vm)
        {
            nationality.addNewNati(vm.nationality);
            List<Nationality> li = nationality.getNationalies();
            vm.ListNationalities = li;
            return View("Index",vm);
        }
        public IActionResult delete(int id)
        {
            nationality.delete(id);
            List<Nationality> li = nationality.getNationalies();
            vmNationality vm = new vmNationality();
            vm.ListNationalities = li;
            return View("Index",vm);
        }
    }
}
