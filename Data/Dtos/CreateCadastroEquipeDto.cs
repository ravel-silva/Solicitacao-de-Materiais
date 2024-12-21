using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class CreateCadastroEquipeDto
    {
        [Required]
        public string Prefixo { get; set; }
    }
}
