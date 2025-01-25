using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class CreateEquipeDto
    {

        [Required(ErrorMessage = "Informe o Prefixo")]
        [MinLength(6, ErrorMessage = "O Prefixo deve ter no mínimo 6 caracteres")]
        [RegularExpression(@"^\S*$", ErrorMessage = "O Prefixo não pode conter espaços em branco.")]
        public string Prefixo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
