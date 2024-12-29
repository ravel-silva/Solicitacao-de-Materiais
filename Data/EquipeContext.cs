using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Data
{
    public class EquipeContext : DbContext
    {
        public EquipeContext(DbContextOptions<EquipeContext> options) : base(options)
        {   
        }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<EquipeFuncionario> RelationshipEquipeFuncionario { get; set; }
    }
}
