using System;
using System.ComponentModel.DataAnnotations;

namespace selecao_dotnet.Models
{
    public class CartaoCredito
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(16, ErrorMessage = "Este campo deve conter 16 caracteres")]
        [MinLength(16, ErrorMessage = "Este campo deve conter 16 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime? Validade  { get; set; }  

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cvv  { get; set; }  
        public int EstudanteId { get; set; }
        public Estudante Estudante { get; set; }
    }
}