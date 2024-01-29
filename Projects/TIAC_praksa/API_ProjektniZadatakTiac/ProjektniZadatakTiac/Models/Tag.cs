using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektniZadatakTiac.Models
{
    //[Table]
    public class Tag
    {
        public int Id { get; set; }  // Primary key
        public string Name { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
    //public class Tag
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int PostId { }
    //    //public List<PostTag> PostTags { get; set; }
    //}
}
