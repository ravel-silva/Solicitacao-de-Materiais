using Solicitacao_de_Material.Data.Dtos;

namespace Solicitacao_de_Material.Model
{
    public class RequisicaoDeMaterial
    {
        public int Id { get; set; }
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; }

        public ICollection<ListMaterial> Materiais { get; set; }
        public string Status { get; set; }  // Status da requisição (ex: Ativo, Cancelado, Concluído)
        public DateTime DateTime { get; set; } = DateTime.Now; // Data e hora em que a requisição foi feita



    }
}
