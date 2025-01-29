using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Model.Auth
{
    public class Usuario : IdentityUser
    {
        [Required]
        public string Matricula { get; set; }
        [Required]
        public DateTime DataDeCadastro { get; set; } = DateTime.Now;

        public Usuario() : base() { }
        
    }
}
