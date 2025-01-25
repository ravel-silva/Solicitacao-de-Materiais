namespace Solicitacao_de_Material.Model
{
    public class FuncionariosInfo
    {
        public int Id { get; set; }
        public string NomeFuncionario { get; set; }
        public string MatriculaFuncionario { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
