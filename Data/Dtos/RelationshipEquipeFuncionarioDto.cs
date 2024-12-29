using Solicitacao_de_Material.Model;
using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class RelationshipEquipeFuncionarioDto
    {
        [Required]
        public int equipeId { get; set; }
        [Required]
        public int funcionarioId { get; set; }

 

        public DateTime dataEntrada { get; set; } = DateTime.Now;
    }
}
