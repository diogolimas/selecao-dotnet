using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using selecao_dotnet.Data;
using selecao_dotnet.Models;
using Microsoft.AspNetCore.Authorization;

namespace selecao_dotnet.Controllers
{
    [ApiController]
    [Route("v1/cartaocredito")]
    
    public class CartaoCreditoController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<CartaoCredito>>> Get([FromServices] DataContext context)
        {
            var cartoes = await context.CartaoCredito
                .Include(x => x.Estudante)
                .ToListAsync();
            
            return Ok(cartoes);
        }

        
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CartaoCredito>> Post(
            [FromServices] DataContext context,
            [FromBody] CartaoCredito model
        )
        {
            if(ModelState.IsValid)
            {
                context.CartaoCredito.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
    }
}