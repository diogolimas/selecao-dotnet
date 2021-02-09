using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using selecao_dotnet.Data;
using selecao_dotnet.Models;


namespace selecao_dotnet.Controllers
{

    [ApiController]
    [Route("v1/user")]
    public class UserController: ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users = await context.User.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<User>> Post(
            [FromServices] DataContext context,
            [FromBody] selecao_dotnet.Models.User model_sent
        )
        {
            
            if(ModelState.IsValid)
            {
                context.User.Add(model_sent);
                await context.SaveChangesAsync();
                return model_sent;
                
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }   
    }
}
