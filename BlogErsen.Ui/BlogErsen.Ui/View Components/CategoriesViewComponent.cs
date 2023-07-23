using BlogUi.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogErsen.Ui.View_Components
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

            return View(_categoryService.GetAll());  
        }
    }
}
