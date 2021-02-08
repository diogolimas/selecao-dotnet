using System;
using System.ComponentModel.DataAnnotations;

namespace selecao_dotnet.Models
{
    public class Estudante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3,ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]   
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]   
        public string Senha { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]   
        public string Email { get; set; }
        public DateTime? DataNascimento  { get; set; }  
    }
}
