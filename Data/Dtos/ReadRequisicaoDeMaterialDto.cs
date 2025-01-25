using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class ReadRequisicaoDeMaterialDto
    {
        public int Id { get; set; }
        public int EquipeId { get; set; }
        public string EquipeNome { get; set; }

       // public List<ListMaterial> Materiais { get; set; }
        public List<ReadMaterialDto> Materiais { get; set; } // Lista de DTOs de Materiais
        public string Status { get; set; }  // Status da requisição (ex: Ativo, Cancelado, Concluído)
        public DateTime DateTime { get; set; } = DateTime.Now; // Data e hora em que a requisição foi feita
    }
}
