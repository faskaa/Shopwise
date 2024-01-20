using BackEndProject.DAL;
using BackEndProject.Entities;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopwiseDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;


        public AccountController(ShopwiseDbContext context , UserManager<CustomUser> userManager ,SignInManager<CustomUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if(!ModelState.IsValid) return View();
            CustomUser user = await _userManager.FindByNameAsync(login.Username);
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Your username or password is incorrect");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result =  await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Many attemps");
                    return View();
                }
                ModelState.AddModelError(string.Empty, "Your username or password is incorrect");
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM account)
        {
            if(!ModelState.IsValid) return View();
            if(!account.IsTermsAccept)
            {
                ModelState.AddModelError(string.Empty, "You must accept our terms");
            }

            var user = new CustomUser()
            {
                UserName = account.Name,
                Email = account.Email

            };
            IdentityResult result = await _userManager.CreateAsync(user, account.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
