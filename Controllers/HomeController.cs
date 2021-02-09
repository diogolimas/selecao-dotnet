using selecao_dotnet.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using selecao_dotnet.Services;
using System;
using selecao_dotnet.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using selecao_dotnet.Data;
using Microsoft.EntityFrameworkCore;



namespace selecao_dotnet.Controllers
{
    [Route("v1/account")]
    public class HomeController: ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context, [FromBody]User model)
        {
           // var userOne = await context.User.ToListAsync();
            var userOne = await context.User
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Username == model.Username);
            // Recupera o usuário
            var user = UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null && userOne == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            
            
            // Oculta a senha
            if(user != null){
                var token = TokenService.GenerateToken(user);
                user.Password = "";
            
            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
            }else{
                var token = TokenService.GenerateToken(userOne);
                userOne.Password = "";

                return new 
                {
                    user = userOne,
                    token = token
                };
            }
            
            
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}