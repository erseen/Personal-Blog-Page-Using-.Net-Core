using BlogErsen.Entity;
using BlogErsen.Ui.Identity;
using BlogErsen.Ui.Models;
using BlogUi.Business.Abstract;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using ChartData = BlogErsen.Ui.Models.ChartData;

namespace BlogErsen.Ui.Controllers
{
   
    public class AdminController : Controller
    {
        private readonly IPostService  _postService;
        private readonly ICategoryService _categoryService; 

        private readonly UserManager<User> _userManager; 
        private readonly SignInManager<User> _signInManager;
        public AdminController(UserManager<User> userManager,
        SignInManager<User> signInManager,
        IPostService postService,
        ICategoryService categoryService
        )

        {
            _userManager= userManager;
            _postService = postService; 
            _signInManager= signInManager;
            _categoryService = categoryService; 

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) 
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

            ModelState.AddModelError("", "Bilinmeyen bir hata oluştu");
            return View(model);
        }

        [HttpGet]
        public IActionResult Login ()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model); 

            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) 
            {
                ModelState.AddModelError("", "Böyle bir eposta adresi yok ");

            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Panel", "Admin");
            }
            ModelState.AddModelError("", "Şifre veya eposta adresi hatalı");
            return View(model);
            
        }
        public IActionResult Panel()
        {
            // Verileri oluşturun (örnek olarak rastgele veriler kullanıyoruz)
            var chartDataList = new List<ChartData>
            {
                new ChartData { Label = "Veri 1", Value = 75 },
                new ChartData { Label = "Veri 2", Value = 60 },
                new ChartData { Label = "Veri 3", Value = 45 },
                new ChartData { Label = "Veri 4", Value = 30 }
            };
            // View'e verileri gönderin
            return View(chartDataList);
        }
        public async Task <IActionResult> Logout ()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CreatePost()
        {
           ViewBag.Categories= Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(PostModel model)
        {
         
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var entity = new Post()
            {
                PostTitle = model.PostTitle,
                Postcontent = model.Postcontent,
                PostPublishedDate = model.PostPublishedDate,
                CategoryId=model.CategoryId,
               
            };
            try
            {
                _postService.Create(entity);
                ViewBag.Message = "success";
            }
            catch (Exception)
            {

                ViewBag.Message = "danger"; 
            }
           
            return View();
        }
      
    }
}
