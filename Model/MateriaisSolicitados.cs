namespace Solicitacao_de_Material.Model
{
    public class MateriaisSolicitados
    {
        public int Id { get; set; }
        public int RequisicaoDeMaterialId { get; set; }
        public RequisicaoDeMaterial RequisicaoDeMaterial { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int QuantidadeSolicitada { get; set; }
    }
}
