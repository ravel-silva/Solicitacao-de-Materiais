using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class CreateRequisicaoDeMaterial
    {
        public class RequisicaoDeMaterial
        {
            public int Id { get; set; }

            public int EquipeId { get; set; }
            public string EquipePrefixo { get; set; }

            public int MaterialId { get; set; }
            public string materialNome { get; set; }

            public int QuantidadeSolicitada { get; set; }
            public DateTime DateTime { get; set; } = DateTime.Now;
        }
    }
}
