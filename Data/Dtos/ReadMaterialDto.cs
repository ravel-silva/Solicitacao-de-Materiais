using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class ReadMaterialDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public string Unidade { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
