using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using P1TaskFlow.DTOs.Tasks.Get.Response;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;
//using P1TaskFlow.DTOs.Users;

namespace P1TaskFlow.Links
{
    public class UserLinksService
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IUrlHelper _urlHelper;

        public UserLinksService(IHttpContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory, IUrlHelper urlHelper)
        {
            _urlHelperFactory = urlHelperFactory;
            _urlHelper = _urlHelperFactory.GetUrlHelper(contextAccessor.HttpContext);
            _urlHelper = urlHelper;
        }

        public UserGETResponseDTO GenerateLinks(UserGETResponseDTO userDto)
        {
            userDto.Links.Add(new LinkDTO(_urlHelper.Link("GetUserById", new { id = userDto.Id }), "self", "GET"));
            userDto.Links.Add(new LinkDTO(_urlHelper.Link("UpdateUser", new { id = userDto.Id }), "update_user", "PUT"));
            userDto.Links.Add(new LinkDTO(_urlHelper.Link("DeleteUser", new { id = userDto.Id }), "delete_user", "DELETE"));

            return userDto;
        }
    }
}
