using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class ReadMaterialDto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]

        public int Quantidade { get; set; }
        public string Unidade { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
