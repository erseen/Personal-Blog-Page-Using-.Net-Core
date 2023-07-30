using BlogErsen.Entity;

namespace BlogErsen.Ui.ViewModels
{
    public class PostDetailsModel
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
