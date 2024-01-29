using Microsoft.AspNetCore.Mvc;
using P1TaskFlow.DataAcess.Tasks;
using P1TaskFlow.Models;
using Microsoft.EntityFrameworkCore;
using P1TaskFlow.DataAcess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1TaskFlow.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class TodoTaskController :ControllerBase
    {

        private readonly DatabaseContext _context;

        public TodoTaskController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoTask>>> GetTasks()
        {
            var tasks = await _context.TodoTasks.ToListAsync();
            if (tasks.Count == 0)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoTask>> GetTaskById(int id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TodoTask>> CreateTask([FromBody] TodoTask task)
        {
            _context.TodoTasks.Add(task);
            await _context.SaveChangesAsync();
            return Created($"/tasks/{task.Id}", task);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoTask>> UpdateTask(int id, [FromBody] TodoTask task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TodoTasks.Any(t => t.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(task);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.TodoTasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }




        /////<summary>
        /////Get tasks
        /////</summary>
        //[HttpGet]
        //public ActionResult<List<TodoTask>> GetTasks()
        //{
        //    var response = new TodoTaskMockRepository().GetTasks();
        //    if(response.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(response);
        //    //return new TodoTaskMockRepository().GetTasks();
        //}

        /////<summary>
        /////Returns a task by its id
        /////</summary>
        //[HttpGet("id")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]

        //public ActionResult<List<TodoTask>> GetTaskById(int id)
        //{
        //    var result = new TodoTaskMockRepository().GetTaskById(id);
        //    if(result != null)
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
        //public ActionResult<TodoTask> CreateTask([FromBody] TodoTask task)
        //{
        //    var createdTask = new TodoTaskMockRepository().CreateTask(task);
        //    return Created($"/tasks/", createdTask);
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
        //public ActionResult<TodoTask> UpdateTask([FromBody] TodoTask task)
        //{
        //    var result = new TodoTaskMockRepository().UpdateTask(task);
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
        //public ActionResult<TodoTask> DeleteTask(int id)
        //{
        //    TodoTask deletedTask = new TodoTaskMockRepository().DeleteTaskById(id);
        //    if (deletedTask == null)
        //    {
        //        return NotFound(); // Task with the given ID was not found
        //    }
        //    var remainingTasks = new TodoTaskMockRepository().GetTasks(); // Adjust this based on your repository implementation
        //    if (remainingTasks.Count == 0)
        //    {
        //        return Ok("Task was deleted and the list is now empty.");
        //    }
        //    return NoContent();
        //}
    }
}
