using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Model
{
    public class Funcionario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Matricula { get; set; }

        public virtual ICollection<EquipeFuncionario> EquipesFuncionarios { get; set; }
    }
}
