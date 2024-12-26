using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Model
{
    public class CadastroFuncionario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Matricula { get; set; }
    }
}
