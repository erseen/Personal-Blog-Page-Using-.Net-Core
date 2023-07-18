using BlogErsen.Ui.Identity;
using BlogErsen.Ui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogErsen.Ui.Controllers
{
   
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager; 
        private readonly SignInManager<User> _signInManager;
        public AdminController(UserManager<User> userManager,
        SignInManager<User> signInManager)

        {
            _userManager= userManager;
            _signInManager= signInManager;  

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid) 
            {
                return View(model);

            }
            var user = new User()
            {
                FirstName=model.FirstName,
                LastName=model.LastName,
                UserName=model.UserName,
                Email=model.Email,  

            };

            var result = await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }


    }
}
