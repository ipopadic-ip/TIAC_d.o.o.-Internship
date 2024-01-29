namespace ProjektniZadatakTiac.DTO.POST.Response
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        //public IEnumerable<TagDTO> Tags { get; set; }
        public List<string> Tags { get; set; }
        public bool Archived { get; set; }
        public int Likes { get; set; }
        public int UserId { get; set; }
        //public List<int> LikedByUserIds { get; set; }
    }
}
