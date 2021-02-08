using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using selecao_dotnet.Data;
using selecao_dotnet.Models;

namespace selecao_dotnet.Controllers
{
    [ApiController]
    [Route("v1/estudantes")]
    public class EstudanteController: ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Estudante>>> Get([FromServices] DataContext context)
        {
            var estudantes = await context.Estudante.ToListAsync();
            return Ok(estudantes);
        }


        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Estudante>> Post(
            [FromServices] DataContext context,
            [FromBody]Estudante model_sent
        )
        {
            
            if(ModelState.IsValid)
            {
                context.Estudante.Add(model_sent);
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