namespace New.Entity.ViewModel
{
    public class BlogModel
    {
        public string BlogName { get; set; }

        public ICollection<PostModel> Posts { get; set; }
    }
}
