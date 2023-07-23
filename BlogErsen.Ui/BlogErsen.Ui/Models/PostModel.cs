using BlogErsen.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BlogErsen.Ui.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string Postcontent { get; set; }
        [Required]
        public string PostPublishedDate { get; set; }
        public int CategoryId { get; set; }

        [Required]
        public List<Category> Categories { get; set; }
        [Required]
        // Seçilen kategori bilgisini almak için yeni bir özellik ekleyin
        public int SelectedCategoryId { get; set; }
    }
}
