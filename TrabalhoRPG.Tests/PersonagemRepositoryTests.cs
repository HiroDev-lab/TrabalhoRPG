using Microsoft.EntityFrameworkCore;
using Xunit;

public class PersonagemRepositoryTests
{
    private PersonagemContext CriarContexto()
    {
        var options = new DbContextOptionsBuilder<PersonagemContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new PersonagemContext(options);
    }

    [Fact]
    public void Salvar_AtribuiIdAoModelo()
    {
        using var context = CriarContexto();
        var repo  = new PersonagemRepository(context);

        var modelo = new PersonagemModel { Nome = "Aragorn", Classe = "Guerreiro", PontosDeVida = 8 };
        repo.Salvar(modelo);

        Assert.True(modelo.Id > 0);
    }

    [Fact]
    public void Salvar_PersonagemPodeSerRecuperado()
    {
        using var context = CriarContexto();
        var repo  = new PersonagemRepository(context);

        var modelo = new PersonagemModel
        {
            Nome         = "Gandalf",
            Classe       = "Mago",
            PontosDeVida = 4,
            Forca        = 8,
            Destreza     = 12,
            Constituicao = 10,
            Inteligencia = 18,
            Sabedoria    = 16,
            Carisma      = 14,
            CriadoEm     = DateTime.Now,
        };
        repo.Salvar(modelo);

        var recuperado = repo.BuscarPorId(modelo.Id);

        Assert.NotNull(recuperado);
        Assert.Equal("Gandalf", recuperado.Nome);
        Assert.Equal("Mago",    recuperado.Classe);
        Assert.Equal(18,        recuperado.Inteligencia);
    }

    [Fact]
    public void ListarTodos_RetornaTodosPersonagensSalvos()
    {
        using var context = CriarContexto();
        var repo  = new PersonagemRepository(context);

        repo.Salvar(new PersonagemModel { Nome = "Frodo",  Classe = "Ladino"   });
        repo.Salvar(new PersonagemModel { Nome = "Gimli",  Classe = "Guerreiro" });
        repo.Salvar(new PersonagemModel { Nome = "Legolas", Classe = "Ladino"  });

        var lista = repo.ListarTodos();

        Assert.Equal(3, lista.Count);
    }

    [Fact]
    public void ListarTodos_BancoVazioRetornaListaVazia()
    {
        using var context = CriarContexto();
        var repo  = new PersonagemRepository(context);

        var lista = repo.ListarTodos();

        Assert.Empty(lista);
    }

    [Fact]
    public void BuscarPorId_IdInexistenteRetornaNull()
    {
        using var context = CriarContexto();
        var repo  = new PersonagemRepository(context);

        var resultado = repo.BuscarPorId(999);

        Assert.Null(resultado);
    }

    [Fact]
    public void Deletar_RemovePersonagemDoBanco()
    {
        using var context = CriarContexto();
        var repo  = new PersonagemRepository(context);

        var modelo = new PersonagemModel { Nome = "Sauron", Classe = "Mago" };
        repo.Salvar(modelo);
        repo.Deletar(modelo.Id);

        var resultado = repo.BuscarPorId(modelo.Id);

        Assert.Null(resultado);
    }

    [Fact]
    public void Deletar_IdInexistente_NaoLancaExcecao()
    {
        using var context = CriarContexto();
        var repo  = new PersonagemRepository(context);

        var exception = Record.Exception(() => repo.Deletar(999));

        Assert.Null(exception);
    }

    [Fact]
    public void Salvar_AtributosPersonagemSaoPreservados()
    {
        using var context = CriarContexto();
        var repo  = new PersonagemRepository(context);

        var modelo = new PersonagemModel
        {
            Nome         = "Thorin",
            Classe       = "Guerreiro",
            PontosDeVida = 12,
            Forca        = 17,
            Destreza     = 10,
            Constituicao = 15,
            Inteligencia = 9,
            Sabedoria    = 8,
            Carisma      = 11,
        };
        repo.Salvar(modelo);

        var recuperado = repo.BuscarPorId(modelo.Id)!;

        Assert.Equal(17, recuperado.Forca);
        Assert.Equal(10, recuperado.Destreza);
        Assert.Equal(15, recuperado.Constituicao);
        Assert.Equal(12, recuperado.PontosDeVida);
    }
}
