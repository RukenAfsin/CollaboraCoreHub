using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Threading.Tasks;

namespace SirketDeneme.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<CustomUser> _usermanager;

        public RegisterUserController(UserManager<CustomUser> usermanager)
        {
            _usermanager = usermanager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CustomUserViewModel p)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = new CustomUser();
                {
                    user.Email = p.Email;
                    user.Name = p.Name;
                };
                var result = await _usermanager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
