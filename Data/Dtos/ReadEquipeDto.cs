using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class ReadEquipeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Prefixo { get; set; }
    }
}
