using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class UpdateMaterialDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o codigo"),
            MinLength(6, ErrorMessage = "O codigo deve ter no mínimo 6 digitos"),
            MaxLength(8, ErrorMessage = "O codigo deve ter no máximo 8 digitos")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Informe o nome do material")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a descrição do material")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a quantidade do material")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Informe o unidade do material, ex: UN, M, KG, PÇ")]
        public string Unidade { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
