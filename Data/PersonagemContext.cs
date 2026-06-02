using Microsoft.EntityFrameworkCore;

public class PersonagemContext : DbContext
{
    public PersonagemContext() { }

    public PersonagemContext(DbContextOptions<PersonagemContext> options) : base(options) { }

    public DbSet<PersonagemModel> Personagens { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite("Data Source=rpg.db");
    }
}
