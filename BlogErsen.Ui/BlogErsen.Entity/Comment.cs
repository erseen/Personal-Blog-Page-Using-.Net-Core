using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommendText { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
