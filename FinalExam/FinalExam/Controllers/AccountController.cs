using FinalExam.Models;
using FinalExam.ViewModels.Member;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamLogin2.Controllers
{
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
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel memberregistervm)
        {
            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.FindByNameAsync(memberregistervm.UsrName);
            if (member != null)
            {
                ModelState.AddModelError("UserName", "Bu Istifadeci Adi Istifade olunub");
                return View();
            }

            member = await _userManager.FindByEmailAsync(memberregistervm.Email);
            if (member != null)
            {
                ModelState.AddModelError("Email", "Bu Email Istifade olunub");
                return View();
            }

            AppUser userra = new AppUser();
            userra.FullName = memberregistervm.FullName;
            userra.Email= memberregistervm.Email;
            userra.UserName = memberregistervm.UsrName;

            var resuld = await _userManager.CreateAsync(userra, memberregistervm.Password);
            if (!resuld.Succeeded)
            {
                foreach(var err in resuld.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                    return View();
                }
            }
            var roles =await _userManager.AddToRoleAsync(userra, "Member");
            if (!roles.Succeeded)
            {
                foreach (var err in resuld.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                    return View();
                }
            }
            await _signInManager.SignInAsync(userra, isPersistent: false);
            return RedirectToAction("Index","Home");

        }
    }
}
