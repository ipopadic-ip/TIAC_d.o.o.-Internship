namespace ProjektniZadatakTiac.Models
{
    public class LikedPost
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
