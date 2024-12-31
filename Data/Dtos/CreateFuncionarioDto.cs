using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class CreateFuncionarioDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Matricula { get; set; }
        public int EquipeId { get; set; }

    }
}
