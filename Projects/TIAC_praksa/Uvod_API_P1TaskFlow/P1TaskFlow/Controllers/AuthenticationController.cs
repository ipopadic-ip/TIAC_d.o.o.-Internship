using Microsoft.AspNetCore.Mvc;
using P1TaskFlow.DataAcess.Tasks;
using P1TaskFlow.Models;
using Microsoft.EntityFrameworkCore;
using P1TaskFlow.DataAcess;
using System.Linq;
using System.Threading.Tasks;

namespace P1TaskFlow.Controllers
{

    [ApiController]
    [Route("api/login")]
    [Consumes("application/json")]
    [Produces("application/json", "application/xml")]
    public class AuthenticationController : ControllerBase
    {

        private readonly DatabaseContext _context;

        public AuthenticationController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{Password}/{Email}")]
        public async Task<ActionResult<User>> Login(string Password, string Email)
        {
            var user = await _context.authentications.FirstOrDefaultAsync(u => u.Password == Password && u.Email == Email);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }


        //[HttpGet("{Password}/{Email}")]
        //public ActionResult<List<User>> Login(string Password, string Email)
        //{
        //    var response = new UsersMockRepository().GetUser(Password, Email);
        //    if (response == null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(response);
        //    //return new TodoTaskMockRepository().GetTasks();
        //}
    }
}
