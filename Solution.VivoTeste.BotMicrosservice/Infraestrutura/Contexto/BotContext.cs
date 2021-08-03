using Microsoft.EntityFrameworkCore;
using Solution.VivoTeste.BotMicrosservice.Dominio.Entidade;

namespace Solution.VivoTeste.BotMicrosservice.Infraestrutura.Contexto
{
    public class BotContext : DbContext
    {
        public BotContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BotEntity> Bot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BotEntity>().HasKey("Id");
            modelBuilder.Entity<BotEntity>().Property(o => o.Name).HasColumnName("Name");
            modelBuilder.Entity<BotEntity>().ToTable("Bot");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
    }
}
