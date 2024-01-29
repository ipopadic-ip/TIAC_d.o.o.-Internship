using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatakTiac.DataAcess.Tasks.Interfaces;
using ProjektniZadatakTiac.DTO.POST.Response;
using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.Controllers
{
    [ApiController]
    [Route("api/posts")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet("{postId}")]
        public IActionResult GetPostById(int postId)
        {
            try
            {
                var post = _postRepository.GetPostById(postId);
                if (post == null)
                    return NotFound();

                var postDTO = _mapper.Map<PostDTO>(post);
                postDTO.Tags = post.Tags.Select(tag => tag.Name).ToList(); // Extract tag names
                return Ok(postDTO);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("byUser/{userId}")]
        public IActionResult GetPostsByUser(int userId)
        {
            try
            {
                var posts = _postRepository.GetPostsByUser(userId);
                var postDTOs = _mapper.Map<IEnumerable<PostDTO>>(posts);
                return Ok(postDTOs);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("byTag/{tagName}")]
        public IActionResult GetPostsByTag(string tagName)
        {
            try
            {
                var posts = _postRepository.GetPostsByTag(tagName);
                var postDTOs = new List<PostDTO>();

                foreach (var post in posts)
                {
                    var postDTO = _mapper.Map<PostDTO>(post);
                    postDTO.Tags = post.Tags.Select(tag => tag.Name).ToList(); // Extract tag names
                    postDTOs.Add(postDTO);
                }

                return Ok(postDTOs);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public IActionResult CreatePost(PostDTO postDTO)
        {
            try
            {
                var post = _mapper.Map<Post>(postDTO);
                _postRepository.CreatePost(post);
                return CreatedAtAction(nameof(GetPostById), new { postId = post.Id }, postDTO);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPut("{postId}")]
        public IActionResult UpdatePost(int postId, UpdatePostDTO updatePostDTO)
        {
            try
            {
                var post = _postRepository.GetPostById(postId);
                if (post == null)
                    return NotFound();

                post.Content = updatePostDTO.Content;
                _postRepository.UpdatePost(post);

                return Ok();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int postId)
        {
            try
            {
                var result = _postRepository.DeletePost(postId);
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

        // Other action methods with try-catch blocks

        [HttpPut("deactivate/{postId}")]
        public IActionResult DeactivatePost(int postId)
        {
            try
            {
                var post = _postRepository.GetPostById(postId);
                if (post == null)
                    return NotFound();

                post.Archived = false;
                _postRepository.UpdatePost(post);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        public static List<int> LikedByUserIds = new List<int>();
        [HttpPost("like/{userId}/{postId}")]
        public IActionResult LikePost(int userId, int postId)
        {
            try
            {
                var post = _postRepository.GetPostById(postId);
                if (post == null)
                    return NotFound();
                if (!LikedByUserIds.Contains(userId))
                {
                    post.Likes ++;
                    LikedByUserIds.Add(userId);
                    _postRepository.UpdatePost(post);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("byLikes")]
        public IActionResult GetPostsByLikes()
        {
            try
            {
                var posts = _postRepository.GetPostsSortedByLikes();
                var postDTOs = _mapper.Map<IEnumerable<PostDTO>>(posts);

                foreach (var postDTO in postDTOs)
                {
                    postDTO.Tags = posts.FirstOrDefault(p => p.Id == postDTO.Id)?.Tags?.Select(tag => tag.Name).ToList();
                }

                return Ok(postDTOs);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


    }
}
