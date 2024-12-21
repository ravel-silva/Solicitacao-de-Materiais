using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Model
{
    public class CadastroEquipe
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Prefixo { get; set; }
    }
}
