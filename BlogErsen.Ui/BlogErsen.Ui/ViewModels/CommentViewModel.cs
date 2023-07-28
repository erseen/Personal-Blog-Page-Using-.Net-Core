using BlogErsen.Entity;

namespace BlogErsen.Ui.ViewModels
{
    public class CommentViewModel
    {
        public List<Comment> Comments { get; set; }
        public List<Post> PostByComments { get; set; }
    }
}
