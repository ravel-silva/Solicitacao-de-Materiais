using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class ReadFuncionarioDto
    {
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage = "Informe o nome do funcionario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a matricula do funcionario")]
        public string Matricula { get; set; }
    }
}
