using Microsoft.AspNetCore.Mvc;
using P1TaskFlow.DataAcess.Tasks;
using P1TaskFlow.Models;
using Microsoft.EntityFrameworkCore;
using P1TaskFlow.DataAcess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P1TaskFlow.DTOs.Tasks.Get.Response;
using AutoMapper;
using P1TaskFlow.DTOs.Tasks.Post.Response;
using P1TaskFlow.DTOs.Tasks.Put.Response;
using P1TaskFlow.Links;

namespace P1TaskFlow.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserLinksService _userLinksService;

        public UsersController(UserRepository userRepository, IMapper mapper, UserLinksService userLinksService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userLinksService = userLinksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserGETResponseDTO>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            var userDTOs = _mapper.Map<List<UserGETResponseDTO>>(users);
            //var userDTOs = users.Select(u => _mapper.Map<UserResponseDTO>(u)).ToList();
            foreach (var userDto in userDTOs)
            {
                _userLinksService.GenerateLinks(userDto);
            }

            if (userDTOs.Count == 0)
            {
                return NotFound();
            }
            return Ok(userDTOs);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserGETResponseDTO>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                var userDto = _mapper.Map<UserGETResponseDTO>(user);
                return Ok(_userLinksService.GenerateLinks(userDto));
                //return Ok(_mapper.Map<UserGETResponseDTO>(user));
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserGETResponseDTO>> CreateUser([FromBody] UserCreateDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            var newUser = _mapper.Map<User>(userDto);
            var createdUser = await _userRepository.CreateUserAsync(newUser);

            var userResponseDto = _mapper.Map<UserGETResponseDTO>(createdUser);
            _userLinksService.GenerateLinks(userResponseDto);

            return Created($"/api/users/{userResponseDto.Id}", userResponseDto);
        }
        //public async Task<ActionResult<UserGETResponseDTO>> CreateUser([FromBody] User user)
        //{
        //    var createdUser = await _userRepository.CreateUserAsync(user);
        //    var userDTO = _mapper.Map<UserGETResponseDTO>(createdUser);
        //    return Created($"/users/{userDTO.Id}", userDTO);
        //}

        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserGETResponseDTO>> UpdateUser(int id, [FromBody] UserUpdateDTO userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _mapper.Map(userDto, existingUser); // Update the existingUser with the properties from userDto

            var updatedUser = await _userRepository.UpdateUserAsync(existingUser);
            var updatedUserDto = _mapper.Map<UserGETResponseDTO>(updatedUser);
            _userLinksService.GenerateLinks(updatedUserDto);

            return Ok(updatedUserDto);
            //return Ok(_mapper.Map<UserGETResponseDTO>(updatedUser));
        }

        //public async Task<ActionResult<UserGETResponseDTO>> UpdateUser(int id, [FromBody] User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var updatedUser = await _userRepository.UpdateUserAsync(user);
        //    if (updatedUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<UserGETResponseDTO>(updatedUser));
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _userRepository.DeleteUserAsync(id);
            if (deletedUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }



        //private readonly UserRepository _userRepository;

        //public UsersController(UserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<UserResponseDTO>>> GetUsers()
        //{
        //    var users = await _userRepository.GetUsersAsync();
        //    var userDTOs = users.Select(u => MapUserToDTO(u)).ToList();
        //    if (userDTOs.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(userDTOs);
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<UserResponseDTO>> GetUserById(int id)
        //{
        //    var user = await _userRepository.GetUserByIdAsync(id);
        //    if (user != null)
        //    {
        //        return Ok(MapUserToDTO(user));
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public async Task<ActionResult<UserResponseDTO>> CreateUser([FromBody] User user)
        //{
        //    var createdUser = await _userRepository.CreateUserAsync(user);
        //    var userDTO = MapUserToDTO(createdUser);
        //    return Created($"/users/{userDTO.Id}", userDTO);
        //}

        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<UserResponseDTO>> UpdateUser(int id, [FromBody] User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var updatedUser = await _userRepository.UpdateUserAsync(user);
        //    if (updatedUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(MapUserToDTO(updatedUser));
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var deletedUser = await _userRepository.DeleteUserAsync(id);
        //    if (deletedUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        //private static UserResponseDTO MapUserToDTO(User user)
        //{
        //    return new UserResponseDTO
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Email = user.Email
        //    };
        //}

        /////<summary>
        /////Get tasks
        /////</summary>
        //[HttpGet]
        //public ActionResult<List<User>> GetUsers()
        //{
        //    var response = new UsersMockRepository().GetUsers();
        //    if (response.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(response);
        //    //return new TodoTaskMockRepository().GetTasks();
        //}

        /////<summary>
        /////Returns a user by its id
        /////</summary>
        //[HttpGet("id")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]

        //public ActionResult<List<TodoTaskGropup>> GetUserById(int id)
        //{
        //    var result = new UsersMockRepository().GetUserById(id);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound();
        //}
        /////<summary>
        /////Creates new user
        /////</summary>
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public ActionResult<User> CreateUser([FromBody] User user)
        //{
        //    var createdUser = new UsersMockRepository().CreateUser(user);
        //    return Created($"/users", createdUser);
        //}
        /////<summary>
        /////Options you can do
        /////</summary>
        //[HttpOptions]
        //public IActionResult GetOptions()
        //{
        //    Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
        //    return Ok();
        //}
        /////<summary>
        /////Updates User
        /////</summary>
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public ActionResult<User> UpdateUser([FromBody] User user)
        //{
        //    var result = new UsersMockRepository().UpdateUser(user);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return null;

        //}

        /////<summary>
        /////Delete User by ID
        /////</summary>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<User> DeleteUser(int id)
        //{
        //    User deletedUser = new UsersMockRepository().DeleteUserById(id);
        //    if (deletedUser == null)
        //    {
        //        return NotFound(); // Task with the given ID was not found
        //    }
        //    var remainingUsers = new UsersMockRepository().GetUsers(); // Adjust this based on your repository implementation
        //    if (remainingUsers.Count == 0)
        //    {
        //        return Ok("Task was deleted and the list is now empty.");
        //    }
        //    return NoContent();
        //}
    }
}
