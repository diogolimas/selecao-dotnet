using Microsoft.EntityFrameworkCore;
using selecao_dotnet.Models;

namespace selecao_dotnet.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)

        {

        }
        //coleções que eu quero utilizar e salvar localmente no pc
        public DbSet<Estudante> Estudante { get; set; }
        public DbSet<CartaoCredito> CartaoCredito { get;set; }
    }
}