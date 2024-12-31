using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class CreateEquipeDto
    {
        [Required]
        public string Prefixo { get; set; }
    }
}
