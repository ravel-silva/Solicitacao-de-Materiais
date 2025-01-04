namespace Solicitacao_de_Material.Model
{
    public class RequisicaoDeMaterial
    {
        public int Id { get; set; }

        public int EquipeId { get; set; }
        public Equipe equipe { get; set; }

        public int MaterialId { get; set; }
        public Material material { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public virtual ICollection<MateriaisSolicitados> MateriaisSolicitados { get; set; }
    }
}
