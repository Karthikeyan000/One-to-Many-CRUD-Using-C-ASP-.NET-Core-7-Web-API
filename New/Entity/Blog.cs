using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        public string BlogName { get; set; }

        public List<Post> Posts { get; set; }
    }
}
