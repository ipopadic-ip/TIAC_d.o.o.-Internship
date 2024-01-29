namespace ProjektniZadatakTiac.DTO.COMMENT.Response
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
