using Microsoft.EntityFrameworkCore;
using Xunit;

public class PersonagemContextTests
{
    private PersonagemContext CriarContexto()
    {
        var options = new DbContextOptionsBuilder<PersonagemContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new PersonagemContext(options);
    }

    [Fact]
    public void DbSet_Personagens_NaoEhNulo()
    {
        using var context = CriarContexto();
        Assert.NotNull(context.Personagens);
    }

    [Fact]
    public void AdicionarPersonagem_SalvaNoContexto()
    {
        using var context = CriarContexto();

        var modelo = new PersonagemModel
        {
            Nome         = "Thorin",
            Classe       = "Guerreiro",
            PontosDeVida = 10,
            Forca        = 16,
            Destreza     = 12,
            Constituicao = 14,
            Inteligencia = 8,
            Sabedoria    = 10,
            Carisma      = 9,
            CriadoEm     = DateTime.Now,
        };

        context.Personagens.Add(modelo);
        context.SaveChanges();

        Assert.Equal(1, context.Personagens.Count());
    }

    [Fact]
    public void AdicionarPersonagem_AtribuiIdAutomatico()
    {
        using var context = CriarContexto();

        var modelo = new PersonagemModel { Nome = "Elara", Classe = "Mago", PontosDeVida = 4 };
        context.Personagens.Add(modelo);
        context.SaveChanges();

        Assert.True(modelo.Id > 0);
    }

    [Fact]
    public void AdicionarMultiplos_ContagemCorreta()
    {
        using var context = CriarContexto();

        context.Personagens.Add(new PersonagemModel { Nome = "A", Classe = "Guerreiro" });
        context.Personagens.Add(new PersonagemModel { Nome = "B", Classe = "Clerigo" });
        context.Personagens.Add(new PersonagemModel { Nome = "C", Classe = "Ladino" });
        context.SaveChanges();

        Assert.Equal(3, context.Personagens.Count());
    }

    [Fact]
    public void RemoverPersonagem_ReducContagem()
    {
        using var context = CriarContexto();

        var modelo = new PersonagemModel { Nome = "Kael", Classe = "Mago" };
        context.Personagens.Add(modelo);
        context.SaveChanges();

        context.Personagens.Remove(modelo);
        context.SaveChanges();

        Assert.Equal(0, context.Personagens.Count());
    }

    [Fact]
    public void BuscarPorId_RetornaPersonagemCorreto()
    {
        using var context = CriarContexto();

        var modelo = new PersonagemModel { Nome = "Zara", Classe = "Ladino", PontosDeVida = 6 };
        context.Personagens.Add(modelo);
        context.SaveChanges();

        var encontrado = context.Personagens.Find(modelo.Id);

        Assert.NotNull(encontrado);
        Assert.Equal("Zara", encontrado.Nome);
    }
}
