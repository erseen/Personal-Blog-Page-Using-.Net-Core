using BlogErsen.Ui.Models;
using BlogErsen.Ui.ViewModels;
using BlogUi.Business.Abstract;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace BlogErsen.Ui.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;

        public HomeController(IPostService postService,
            ICommentService commentService,
            ICategoryService categoryService
            )
        {
            _postService = postService;
            _commentService = commentService;
            _categoryService=categoryService;
             
        }
     
        public IActionResult Index()
        {
            var postViewModel = new PostViewModel
            {
                Posts = _postService.GetAll()

            };
            return View(postViewModel);
        }
        public IActionResult Details(int id) 
        {
            var postDetailsModel = new PostDetailsModel()
            {
                Post = _postService.GetById(id),
                Comments = _commentService.GetProvedCommentsByPostId(id)

            };
            return View(postDetailsModel);
        
        }
        //[HttpGet]
        //public PartialViewResult SendCategoriestoNavbar()
        //{
     
        //    return PartialView("_navbar", _categoryService.GetAll());
        //}

        public IActionResult GetPostByCategoryId(int id)
        {
            var postListViewModel = new PostViewModel()
            {
                Posts = _postService.GetPostByCategoryId(id)
            };
            return View(postListViewModel);

        }
        public IActionResult Register()
        {
            
            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}