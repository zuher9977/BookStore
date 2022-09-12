using identitiy.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Models;

namespace task.Services
{
    public class AccountServices:IAccountServices
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        public AccountServices(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }


        public async Task<IdentityResult> Create(CreateAccountModel createAccountModel) 
        { 
            ApplicationUser user = new ApplicationUser();
            user.Name = createAccountModel.Name;
            user.UserName = createAccountModel.Email;
            user.Email = createAccountModel.Email;

            var result = await userManager.CreateAsync(user, createAccountModel.Password);
            return result;
        }

        public async Task<SignInResult> Login(LoginModel loginModel)
        {
            var result = await signInManager.PasswordSignInAsync(loginModel.Name, loginModel.Password, loginModel.isSelected, false);
            return result;
        }
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public List<IdentityRole> getRoles()
        {
            List<IdentityRole> li=roleManager.Roles.ToList();
            return li;
        }
        public async Task AddRole(AddRoleModel addRoleModel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = addRoleModel.Name;
            await roleManager.CreateAsync(role);
        }

        public List<ApplicationUser> getUsers()
        {
            List<ApplicationUser> li = userManager.Users.ToList();
            return li;
        }
        public List<ApplicationUser> getUsersByName(string Name)
        {
            List<ApplicationUser> li = userManager.Users.Where(name => name.Name == Name).ToList();
            return li;
        }
        public async Task<List<UserRolesModel>> getRoles(string userId)
        {
            List<UserRolesModel> LiUserRole = new List<UserRolesModel>();
            List<IdentityRole> LiRole = roleManager.Roles.ToList();
            foreach (IdentityRole item in LiRole)
            {
                UserRolesModel uRole = new UserRolesModel();
                uRole.RoleId = item.Id;
                uRole.RoleName = item.Name;
                uRole.isSelected = false;
                uRole.UserId = userId;
                LiUserRole.Add(uRole);
            }

            foreach (UserRolesModel item in LiUserRole)
            {
                var user = await userManager.FindByIdAsync(item.UserId);
                var LiRoleOfUser = await userManager.GetRolesAsync(user);
                foreach (var roleName in LiRoleOfUser)
                {
                    if (item.RoleName == roleName)
                    {
                        item.isSelected = true;
                    }
                }
            }

            return LiUserRole;

        }

        public async Task UpDateUserRole(List<UserRolesModel> LiuserRolesModels)
        {
            foreach (var item in LiuserRolesModels)
            {
                var user = await userManager.FindByIdAsync(item.UserId);
                var role = await roleManager.FindByIdAsync(item.RoleId);

                if (item.isSelected == true)
                {
                    if (await userManager.IsInRoleAsync(user, role.Name) == false) // اذا مش موجودة ضيفها مشان هيك فولز
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                }
                else
                {
                    if (await userManager.IsInRoleAsync(user, role.Name) == true) // اذا موجودة بالتيبل احذفها مشان هيك ترو
                    {
                        await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                }
            }
        }

        public async Task<ApplicationUser> getusername(string UserId)
        {
            var user = await userManager.FindByIdAsync(UserId);
            return user;
        }

        public ApplicationUser getuser(string id)
        {
            ApplicationUser applicationUser= userManager.Users.Where(i => i.Id == id).First();
            return applicationUser;
        }
        public async Task<IdentityResult> Update(CreateAccountModel createAccountModel)
        {
            string id = createAccountModel.Id;
            ApplicationUser userInfo = await userManager.FindByIdAsync(id);
            userInfo.Name = createAccountModel.Name;
            userInfo.UserName = createAccountModel.Email;

            var result = await userManager.UpdateAsync(userInfo);
            return result;
        }
        public int usercount()
        {
            int count = userManager.Users.Count();
            return count;
        }
    }
}
