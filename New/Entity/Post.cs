using System.ComponentModel.DataAnnotations;

namespace New.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string PostName { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
