using BlogErsen.Ui.ViewModels;
using BlogUi.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogErsen.Ui.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
       private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var categoryListViewModel = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            };
           
            return View(categoryListViewModel);
            
        }
    }
}
