using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Model
{
    public class Equipe
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Prefixo { get; set; }

        public virtual ICollection<EquipeFuncionario> EquipesFuncionarios { get; set; }
    }
}
