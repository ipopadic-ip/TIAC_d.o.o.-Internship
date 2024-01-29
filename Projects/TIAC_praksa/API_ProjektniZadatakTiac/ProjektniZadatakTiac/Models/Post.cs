using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektniZadatakTiac.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public bool Archived { get; set; }
        public int UserId { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        //[NotMapped]
        //public ICollection<int> LikedByUserIds { get; set; } = new List<int>();
        //public ICollection<LikedPost> LikedByUsers { get; set; } = new List<LikedPost>();
    }
}
