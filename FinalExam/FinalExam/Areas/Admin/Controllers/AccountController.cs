using FinalExam.Areas.Admin.ViewModels;
using FinalExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = await _userManager.FindByNameAsync(adminLoginViewModel.UserName);
            if (appUser == null)
            {
                ModelState.AddModelError("UserName", "Yanlisdilar");
                return View();
            }
            var password = await _signInManager.PasswordSignInAsync(appUser, adminLoginViewModel.Password, false, false);
            if (!password.Succeeded)
            {
                ModelState.AddModelError("Password", "Yanlisdilar");
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
