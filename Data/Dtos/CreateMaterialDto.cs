using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class CreateMaterialDto
    {

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Unidade { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
