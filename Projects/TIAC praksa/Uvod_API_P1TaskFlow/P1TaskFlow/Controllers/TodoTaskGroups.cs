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
    [Route("api/tasks/group")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class TodoTaskGroups : ControllerBase
    {

        private readonly TodoTaskGroupRepository _taskGroupRepository;

        public TodoTaskGroups(TodoTaskGroupRepository taskGroupRepository)
        {
            _taskGroupRepository = taskGroupRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoTaskGropup>>> GetTaskGroups()
        {
            var groupTasks = await _taskGroupRepository.GetTaskGroupsAsync();
            if (groupTasks.Count == 0)
            {
                return NotFound();
            }
            return Ok(groupTasks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoTaskGropup>> GetTaskGroupById(int id)
        {
            var taskGroup = await _taskGroupRepository.GetTaskGroupByIdAsync(id);
            if (taskGroup != null)
            {
                return Ok(taskGroup);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TodoTaskGropup>> CreateTaskGroup([FromBody] TodoTaskGropup taskGroup)
        {
            var createdTaskGroup = await _taskGroupRepository.CreateTaskGroupAsync(taskGroup);
            return Created($"/tasks/group/{createdTaskGroup.Id}", createdTaskGroup);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoTaskGropup>> UpdateTaskGroup(int id, [FromBody] TodoTaskGropup taskGroup)
        {
            if (id != taskGroup.Id)
            {
                return BadRequest();
            }

            var updatedTaskGroup = await _taskGroupRepository.UpdateTaskGroupAsync(taskGroup);
            if (updatedTaskGroup == null)
            {
                return NotFound();
            }

            return Ok(updatedTaskGroup);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTaskGroup(int id)
        {
            var deletedTaskGroup = await _taskGroupRepository.DeleteTaskGroupAsync(id);
            if (deletedTaskGroup == null)
            {
                return NotFound();
            }

            return NoContent();
        }



        //private readonly DatabaseContext _context;

        //public TodoTaskGroups(DatabaseContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<TodoTaskGropup>>> GetTasks()
        //{
        //    var groupTasks = await _context.todoTaskGropups.ToListAsync();
        //    if (groupTasks.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(groupTasks);
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<TodoTaskGropup>> GetTaskById(int id)
        //{
        //    var taskGroup = await _context.todoTaskGropups.FindAsync(id);
        //    if (taskGroup != null)
        //    {
        //        return Ok(taskGroup);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public async Task<ActionResult<TodoTaskGropup>> CreateTask([FromBody] TodoTaskGropup taskGroup)
        //{
        //    _context.todoTaskGropups.Add(taskGroup);
        //    await _context.SaveChangesAsync();
        //    return Created($"/tasks/group/{taskGroup.Id}", taskGroup);
        //}

        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<TodoTaskGropup>> UpdateTask(int id, [FromBody] TodoTaskGropup taskGroup)
        //{
        //    if (id != taskGroup.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(taskGroup).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_context.todoTaskGropups.Any(t => t.Id == id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Ok(taskGroup);
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeleteTask(int id)
        //{
        //    var taskGroup = await _context.todoTaskGropups.FindAsync(id);
        //    if (taskGroup == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.todoTaskGropups.Remove(taskGroup);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}



        /////<summary>
        /////Get tasks
        /////</summary>
        //[HttpGet]
        //public ActionResult<List<TodoTaskGropup>> GetTasks()
        //{
        //    var response = new TodoTaskGroupMockRespository().GetTasks();
        //    if (response.Count == 0)
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

        //public ActionResult<List<TodoTaskGropup>> GetTaskById(int id)
        //{
        //    var result = new TodoTaskGroupMockRespository().GetTaskById(id);
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
        //public ActionResult<TodoTaskGropup> CreateTask([FromBody] TodoTaskGropup task)
        //{
        //    var createdTask = new TodoTaskGroupMockRespository().CreateTask(task);
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
        //public ActionResult<TodoTaskGropup> UpdateTask([FromBody] TodoTaskGropup task)
        //{
        //    var result = new TodoTaskGroupMockRespository().UpdateTask(task);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return null;

        //}

        /////<summary>
        /////Delete Task by ID
        /////</summary>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<TodoTaskGropup> DeleteTask(int id)
        //{
        //    TodoTaskGropup deletedTask = new TodoTaskGroupMockRespository().DeleteTaskById(id);
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
