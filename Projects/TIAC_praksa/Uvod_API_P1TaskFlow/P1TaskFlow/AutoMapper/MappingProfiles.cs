using AutoMapper;
using P1TaskFlow.DTOs.Tasks.Get.Response;
using P1TaskFlow.DTOs.Tasks.Post.Response;
using P1TaskFlow.DTOs.Tasks.Put.Response;
using P1TaskFlow.Models;

namespace P1TaskFlow.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserGETResponseDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
        }
    }
}
