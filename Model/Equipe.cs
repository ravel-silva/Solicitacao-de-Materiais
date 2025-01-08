using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Model
{
    public class Equipe
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Prefixo")]
        [MinLength(6, ErrorMessage = "O Prefixo deve ter no mínimo 6 caracteres")]
        [RegularExpression(@"^\S*$", ErrorMessage = "O Prefixo não pode conter espaços em branco.")]
        public string Prefixo { get; set; }

        public virtual ICollection<EquipeFuncionario> EquipesFuncionarios { get; set; }
        public virtual ICollection<RequisicaoDeMaterial> RequisicoesDeMaterial { get; set; }
    }
}
