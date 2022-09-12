using identitiy.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Models;

namespace task.Services
{
    public interface IAccountServices
    {
        Task<IdentityResult> Create(CreateAccountModel createAccountModel);
        Task<SignInResult> Login(LoginModel loginModel);
        Task Logout();
        List<IdentityRole> getRoles();
        Task AddRole(AddRoleModel addRoleModel);
        List<ApplicationUser> getUsers();
        List<ApplicationUser> getUsersByName(string Name);
        Task<List<UserRolesModel>> getRoles(string userId);
        Task UpDateUserRole(List<UserRolesModel> LiuserRolesModels);
        Task<ApplicationUser> getusername(string UserId);
        ApplicationUser getuser(string id);
        Task<IdentityResult> Update(CreateAccountModel createAccountModel);
        int usercount();
    }
}
