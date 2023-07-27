using BlogErsen.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

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
        public string PostShortDescription { get; set; }
        [Required]
        public string PostPublishedDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
       
        //This  attribute getting image from database only using in get method
        public string ImageUrl { get; set; }

        //I used same name (ImageUrl and PostImageUrl) but
        //ı fixed iform file to string error with using 2 prop in same model
       
        //This attribute sending image to database only using in post method
        public IFormFile  PostImageUrl { get; set; }

    }
}
