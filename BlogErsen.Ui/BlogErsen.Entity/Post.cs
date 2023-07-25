using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Entity
{
    public class Post
    {
        
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostImageUrl { get; set; }
        public string PostShortDescription { get; set; }
        public string Postcontent { get; set; }
        public string PostPublishedDate { get; set; }
        public int CategoryId { get; set; }
     

    }
}
