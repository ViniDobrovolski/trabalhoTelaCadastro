using Microsoft.EntityFrameworkCore;

namespace TelaCadastro.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes) { }

        public DbSet <TelaCad> telacadastro { get; set; }

        public DbSet<Ender> endereco { get; set; }

        public DbSet<Mensa> mensagem { get; set;}
    }
}
