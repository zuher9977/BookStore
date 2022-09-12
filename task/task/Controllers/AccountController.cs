using identitiy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Models;
using task.Services;

namespace task.Controllers
{
    
    public class AccountController : Controller
    {
        IAccountServices accountServices;
        public AccountController(IAccountServices _accountServices)
        {
            accountServices = _accountServices;
        }
        public IActionResult Index()
        {
            return View("CreateAccount");
        }

        public async Task<IActionResult> CreateAccount(CreateAccountModel createAccountModel)
        {
            var result = await accountServices.Create(createAccountModel);
            return View("CreateAccount");
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logining(LoginModel loginModel)
        { 
            var result = await accountServices.Login(loginModel);
            if(result.Succeeded==true)
            {
                // return RedirectToAction("Index", "DashBoard");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["msg"] = "Invalid Username Or Password";
                return View("Login");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await accountServices.Logout();
            return View("Login");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddRole()
        {

            AddRoleModel RoleList = new AddRoleModel();
            List<IdentityRole> li =  accountServices.getRoles();
            RoleList.li = li;
            return View(RoleList);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddingRole(AddRoleModel addRoleModel)
        {
            await accountServices.AddRole(addRoleModel);
            AddRoleModel RoleList = new AddRoleModel();
            List<IdentityRole> li = accountServices.getRoles();
            RoleList.li = li;
            return View("AddRole", RoleList);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserSearch()
        {
            List<ApplicationUser> li = accountServices.getUsers();
            return View(li);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Searching()
        {
            string Name = Request.Form["NameOfUser"];
            List<ApplicationUser> li = accountServices.getUsersByName(Name);
            return View("UserSearch",li);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoleToUser(String Id, String Name)
        {
            ViewData["Name"] = Name;
            List<UserRolesModel> li = await accountServices.getRoles(Id);
            return View(li);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserRole(List<UserRolesModel> LiuserRolesModels)
        {
            await accountServices.UpDateUserRole(LiuserRolesModels);
            ApplicationUser user = await accountServices.getusername(LiuserRolesModels[0].UserId);
            ViewData["Name"] = user.Name;
            return View("AddRoleToUser", LiuserRolesModels);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string Id)
        {

            ApplicationUser applicationUser= accountServices.getuser(Id);
            CreateAccountModel g = new CreateAccountModel();
            g.Id = applicationUser.Id;
            g.Name = applicationUser.Name;
            g.Email = applicationUser.Email;
            return View("UpdateUserInfo",g);
        }
        public async Task<IActionResult> Update(CreateAccountModel createAccountModel)
        {
            var result = await accountServices.Update(createAccountModel);
            return View("UpdateUserInfo");
        }
    }
}
