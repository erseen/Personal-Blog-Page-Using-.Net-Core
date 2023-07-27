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
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogErsen.Ui.ViewModels;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Razor.TagHelpers;
using DocumentFormat.OpenXml.Office2010.Excel;

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
        [HttpGet]
        public IActionResult Panel()
        {
            // Verileri oluşturun (örnek olarak rastgele veriler kullanıyoruz)
            //var chartDataList = new List<ChartData>
            //{
            //    new ChartData { Label = "Veri 1", Value = 75 },
            //    new ChartData { Label = "Veri 2", Value = 60 },
            //    new ChartData { Label = "Veri 3", Value = 45 },
            //    new ChartData { Label = "Veri 4", Value = 30 }
            //};
            //chartDataList
            //// View'e verileri gönderin
            ViewBag.TotalPostCount = _postService.GetAllPostCount();
            ViewBag.TotalCategoriesCount = _categoryService.GetAllCategoriesCount();
            return View();
        }
        public async Task <IActionResult> Logout ()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CreatePost()
        {
            ViewBag.Message = "";
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var entity = new Post();
            ViewBag.Categories = _categoryService.GetAll();
             if(model.PostImageUrl!= null) 
            {
            var extension = Path.GetExtension(model.PostImageUrl.FileName);
            var newimagename = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/",newimagename);
            var stream = new FileStream(location, FileMode.Create);
            model.PostImageUrl.CopyTo(stream);

            entity.PostImageUrl = newimagename;
            }

            entity.PostTitle = model.PostTitle;
            entity.PostShortDescription= model.PostShortDescription;    
            entity.Postcontent = model.Postcontent;
            entity.PostPublishedDate = model.PostPublishedDate;
            entity.CategoryId = model.CategoryId;

            try
            {
                _postService.Create(entity);
                ViewBag.Message = "success";
                return RedirectToAction("CreatePost", "Admin");
            }
            catch (Exception)
            {

                ViewBag.Message = "danger"; 
            }
           
            return View();
        }
        [HttpGet]
        public IActionResult PostList()
        {
            var postViewModel = new PostViewModel()
            {
                Posts = _postService.GetAll()
            };
            return View(postViewModel);
        }
        public IActionResult DeletePost(int postId)
        {
            var entity =_postService.GetById(postId);
            if(entity!=null)
            {
                _postService.Delete(entity);
                return RedirectToAction("PostList", "Admin");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id ) 
        {
            var postDetailsViewModel = new PostDetailsModel()
            {
                Post = _postService.GetById(id)
            };

            return View(postDetailsViewModel);
        }
       
        
        
        [HttpGet]
        public IActionResult PostUpdate(int id )
        {
            ViewBag.Categories = _categoryService.GetAll();

           
            var entity = _postService.GetById(id);
            if (entity==null)
            {
                return NotFound();
             
            }
            var postmodel = new PostModel()
            {
                PostId = entity.PostId,
                PostTitle = entity.PostTitle,
                PostShortDescription = entity.PostShortDescription,
                PostPublishedDate = entity.PostPublishedDate,
                Postcontent = entity.Postcontent,
                ImageUrl = entity.PostImageUrl,
                CategoryId = entity.CategoryId,

            };
            return View(postmodel);
        }


        [HttpPost]
        public IActionResult PostUpdate(PostModel model,IFormFile file)
        {
            ViewBag.Categories = _categoryService.GetAll();
            var entity = _postService.GetById(model.PostId);
            if (entity == null)
            {
                return NotFound();

            }
            entity.PostTitle = model.PostTitle;
            entity.PostShortDescription = model.PostShortDescription;
            entity.Postcontent = model.Postcontent;
            entity.PostPublishedDate = model.PostPublishedDate;

            if (model.CategoryId!=entity.CategoryId) 
            {
                entity.CategoryId = model.CategoryId;
            
            }
           

            if(model.PostImageUrl!=null)
            {
                var extension = Path.GetExtension(model.PostImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.PostImageUrl.CopyTo(stream);
                entity.PostImageUrl = newimagename;
            }
            _postService.Update(entity);
            return RedirectToAction("PostList");

        }


    }
}
