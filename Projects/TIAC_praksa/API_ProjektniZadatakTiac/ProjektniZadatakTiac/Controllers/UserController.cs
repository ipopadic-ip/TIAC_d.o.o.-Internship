using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatakTiac.DataAcess.Tasks;
using ProjektniZadatakTiac.DataAcess.Tasks.Interfaces;
using ProjektniZadatakTiac.DTO.USER.Response;
using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class UserController : ControllerBase
    {
        //private readonly UserRepository _userRepository;
        //private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);
                if (user == null || !user.IsActive)
                    return NotFound();

                var userDTO = _mapper.Map<UserDTO>(user);
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("searchByEmail")]
        public IActionResult SearchUsersByEmail(string email)
        {
            try
            {
                var users = _userRepository.SearchUsersByEmail(email);
                var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
                return Ok(userDTOs);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("searchByName")]
        public IActionResult SearchUsersByName(string firstName, string lastName)
        {
            try
            {
                var users = _userRepository.SearchUsersByName(firstName, lastName);
                var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
                return Ok(userDTOs);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                _userRepository.CreateUser(user);
                return CreatedAtAction(nameof(GetUserById), new { userId = user.Id }, userDTO);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, UserDTO userDTO)
        {
            try
            {
                var existingUser = _userRepository.GetUserById(userId);
                if (existingUser == null)
                    return NotFound();

                var updatedUser = _mapper.Map(userDTO, existingUser);
                _userRepository.UpdateUser(updatedUser);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                var result = _userRepository.DeleteUser(userId);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPut("deactivate/{userId}")]
        public IActionResult DeactivateUser(int userId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);
                if (user == null)
                    return NotFound();

                user.IsActive = false; // Set user status to inactive
                _userRepository.UpdateUser(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPut("{followerId}/follow/{followingId}")]
        public IActionResult FollowUser(int followerId, int followingId)
        {
            try
            {
                var success = _userRepository.FollowUser(followerId, followingId);

                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        //[HttpGet("{userId}/followers")]
        //public IActionResult GetUserFollowers(int userId)
        //{
        //    try
        //    {
        //        var user = _userRepository.GetUserById(userId);
        //        if (user == null || !user.IsActive)
        //            return NotFound();

        //        var followers = _userRepository.GetFollowers(userId);
        //        var followersDTO = _mapper.Map<IEnumerable<UserFollowerDTO>>(followers);
        //        return Ok(followersDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle or log the exception
        //        return StatusCode(500, "An error occurred while retrieving user followers.");
        //    }
        //}

        //[HttpGet("{userId}/following")]
        //public IActionResult GetUserFollowing(int userId)
        //{
        //    try
        //    {
        //        var user = _userRepository.GetUserById(userId);
        //        if (user == null || !user.IsActive)
        //            return NotFound();

        //        var following = _userRepository.GetFollowing(userId);
        //        var followingDTO = _mapper.Map<IEnumerable<UserFollowingDTO>>(following);
        //        return Ok(followingDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle or log the exception
        //        return StatusCode(500, "An error occurred while retrieving user following.");
        //    }
        //}




    }
}
