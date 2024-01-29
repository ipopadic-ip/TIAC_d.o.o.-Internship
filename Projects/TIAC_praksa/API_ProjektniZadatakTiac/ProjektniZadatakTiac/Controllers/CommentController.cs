using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjektniZadatakTiac.DataAcess.Tasks.Interfaces;
using ProjektniZadatakTiac.DTO.COMMENT.Response;
using ProjektniZadatakTiac.Models;

namespace ProjektniZadatakTiac.Controllers
{
    [ApiController]
    [Route("api/comments")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentController(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        [HttpGet("{commentId}")]
        public IActionResult GetCommentById(int commentId)
        {
            try
            {
                var comment = _commentRepository.GetCommentById(commentId);
                if (comment == null)
                    return NotFound();

                var commentDTO = _mapper.Map<CommentDTO>(comment);
                return Ok(commentDTO);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("byUser/{userId}")]
        public IActionResult GetCommentsByUser(int userId)
        {
            try
            {
                var comments = _commentRepository.GetCommentsByUser(userId);
                var commentDTOs = _mapper.Map<IEnumerable<CommentDTO>>(comments);
                return Ok(commentDTOs);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public IActionResult CreateComment(CommentDTO commentDTO)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentDTO);
                _commentRepository.CreateComment(comment);
                return CreatedAtAction(nameof(GetCommentById), new { commentId = comment.Id }, commentDTO);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPut("{commentId}")]
        public IActionResult UpdateComment(int commentId, CommentDTO commentDTO)
        {
            try
            {
                var existingComment = _commentRepository.GetCommentById(commentId);
                if (existingComment == null)
                    return NotFound();

                var updatedComment = _mapper.Map(commentDTO, existingComment);
                _commentRepository.UpdateComment(updatedComment);
                return Ok(updatedComment);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpDelete("{commentId}")]
        public IActionResult DeleteComment(int commentId)
        {
            try
            {
                var comment = _commentRepository.GetCommentById(commentId);
                if (comment == null)
                    return NotFound();

                _commentRepository.DeleteComment(commentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }



    }
}
