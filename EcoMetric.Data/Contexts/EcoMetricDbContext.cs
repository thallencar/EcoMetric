using EcoMetric.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoMetric.Data.Contexts
{
    public class EcoMetricDbContext : DbContext
    {
        public EcoMetricDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CadastroModel> Cadastros { get; set; }
        public DbSet<ConsumoEnergiaModel> ConsumosEnergia { get; set; }
        public DbSet<RelatorioHardwareModel> RelatoriosEnergiaHardware { get; set; }
        public DbSet<RelatorioEnelModel> RelatoriosEnergiaEnel { get; set; }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<MonitoramentoModel> Monitoramentos { get; set; }
        public DbSet<ProjetoModel> Projetos { get; set; }
        public DbSet<RelatorioModel> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
