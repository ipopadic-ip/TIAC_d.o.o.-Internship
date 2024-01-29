using P1TaskFlow.Links;

namespace P1TaskFlow.DTOs.Tasks.Get.Response
{
    public class UserGETResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<LinkDTO> Links { get; set; } = new List<LinkDTO>();
    }
}
