namespace Solicitacao_de_Material.Model
{
    public class ListMaterial
    {
        public int Id { get; set; }
        public int RequisicaoDeMaterialId { get; set; }
        public int MaterialId { get; set; }
        public int Quantidade { get; set; }

        public RequisicaoDeMaterial RequisicaoDeMaterial { get; set; }
        public Material Material { get; set; }
    }
}
