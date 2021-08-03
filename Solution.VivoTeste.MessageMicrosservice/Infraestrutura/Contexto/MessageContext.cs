using Microsoft.EntityFrameworkCore;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Entidade;

namespace Solution.VivoTeste.MessageMicrosservice.Infraestrutura.Contexto
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MessageEntity> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageEntity>().HasKey("Id");
            modelBuilder.Entity<MessageEntity>().Property(o => o.ConversationId ).HasColumnName("ConversationId");
            modelBuilder.Entity<MessageEntity>().Property(o => o.From ).HasColumnName("From");
            modelBuilder.Entity<MessageEntity>().Property(o => o.To).HasColumnName("To");
            modelBuilder.Entity<MessageEntity>().Property(o => o.TimeStamp).HasColumnName("TimeStamp");
            modelBuilder.Entity<MessageEntity>().Property(o => o.Text).HasColumnName("Text");
            modelBuilder.Entity<MessageEntity>().ToTable("Message");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
    }
}
