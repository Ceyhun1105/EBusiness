using eBusiness.Areas.Admin.ViewModels;
using eBusiness.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Areas;

namespace eBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserManagerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserManagerController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel loginVm)
        {
            if(!ModelState.IsValid) return View(loginVm);
            var user = await _userManager.FindByNameAsync(loginVm.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or Password is invalid");
                return View(loginVm);
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is invalid");
                return View(loginVm);
            }

            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction ("index", "home", new { area = "" });
        }
        








        /* public async Task<IActionResult> CreateAdmin()
         {
             AppUser admin = new AppUser
             {
                 FullName = "Admin",
                 UserName = "Admin"
             };
             var result = await _userManager.CreateAsync(admin, "Admin2023");

             return Ok(result);
         }

         public async Task<IActionResult> CreateRole()
         {
             IdentityRole role1 = new IdentityRole("Admin");
             IdentityRole role2 = new IdentityRole("Member");

             await _roleManager.CreateAsync(role1);
             await _roleManager.CreateAsync(role2);

             return Ok("Created");

         }

         public async Task<IActionResult> SetRole()
         {
             AppUser user = await _userManager.FindByNameAsync("Admin");
             var result = await _userManager.AddToRoleAsync(user, "Admin");
             return Ok(result);
         }*/
    }
}
