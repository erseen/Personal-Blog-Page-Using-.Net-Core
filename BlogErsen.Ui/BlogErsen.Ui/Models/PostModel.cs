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
        public string CategoryName { get; set; }


    }
}
