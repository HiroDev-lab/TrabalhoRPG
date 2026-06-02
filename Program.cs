using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("==============================================");
        Console.WriteLine("   OLD DRAGON RPG - Criacao de Personagem");
        Console.WriteLine("   Trabalho Pratico - Orientacao a Objetos");
        Console.WriteLine("==============================================\n");

        Console.Write("Digite o nome do seu personagem: ");
        string nome = Console.ReadLine() ?? "Aventureiro";

        ClassePersonagem classe = EscolherClasse();
        IDistribuicaoAtributos metodo = EscolherMetodo();

        Console.WriteLine($"\n--- Metodo escolhido: {metodo.Nome} ---");
        Console.WriteLine($"    {metodo.Descricao}");

        Atributos atributos = metodo.Distribuir();
        Personagem personagem = new Personagem(nome, classe, atributos);
        personagem.ExibirFicha();

        Console.WriteLine("\nPersonagem criado com sucesso! Boa aventura!");

        SalvarPersonagem(personagem);
    }

    static void SalvarPersonagem(Personagem personagem)
    {
        Console.Write("\nDeseja salvar este personagem no banco de dados? (s/n): ");
        if ((Console.ReadLine() ?? "").Trim().ToLower() != "s") return;

        using var context = new PersonagemContext();
        context.Database.EnsureCreated();

        var repo  = new PersonagemRepository(context);
        var model = new PersonagemModel
        {
            Nome         = personagem.Nome,
            Classe       = personagem.Classe.Nome,
            PontosDeVida = personagem.PontosDeVida,
            Forca        = personagem.Atributos.Forca,
            Destreza     = personagem.Atributos.Destreza,
            Constituicao = personagem.Atributos.Constituicao,
            Inteligencia = personagem.Atributos.Inteligencia,
            Sabedoria    = personagem.Atributos.Sabedoria,
            Carisma      = personagem.Atributos.Carisma,
            CriadoEm     = DateTime.Now,
        };

        repo.Salvar(model);
        Console.WriteLine($"\n  Personagem salvo com sucesso! (ID no banco: #{model.Id})");

        Console.Write("\nExibir todos os personagens salvos? (s/n): ");
        if ((Console.ReadLine() ?? "").Trim().ToLower() != "s") return;

        var todos = repo.ListarTodos();
        Console.WriteLine($"\n=== PERSONAGENS SALVOS ({todos.Count}) ===");
        Console.WriteLine($"  {"ID",-5} {"Nome",-15} {"Classe",-10} {"HP",-5} {"Criado em",-18}");
        Console.WriteLine(new string('-', 58));
        foreach (var p in todos)
        {
            Console.WriteLine($"  #{p.Id,-4} {p.Nome,-15} {p.Classe,-10} {p.PontosDeVida,-5} {p.CriadoEm:dd/MM/yyyy HH:mm}");
        }
    }

    static ClassePersonagem EscolherClasse()
    {
        List<ClassePersonagem> classes = new List<ClassePersonagem>
        {
            new Guerreiro(),
            new Clerigo(),
            new Mago(),
            new Ladino(),
        };

        Console.WriteLine("\n=== ESCOLHA SUA CLASSE ===");
        for (int i = 0; i < classes.Count; i++)
        {
            string resumo = classes[i].Descricao.Split('.')[0];
            Console.WriteLine($"  [{i + 1}] {classes[i].Nome,-10} d{classes[i].DadoDeVida} HP  —  {resumo}.");
        }

        Console.Write("\nEscolha (1-4): ");
        int opcao;
        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 4)
        {
            Console.Write("  Opcao invalida. Digite um numero entre 1 e 4: ");
        }

        return classes[opcao - 1];
    }

    static IDistribuicaoAtributos EscolherMetodo()
    {
        List<IDistribuicaoAtributos> metodos = new List<IDistribuicaoAtributos>
        {
            new RolagemSequencial(),
            new RolagemLivre(),
            new DistribuicaoPontos(),
        };

        Console.WriteLine("\n=== METODO DE DISTRIBUICAO DE ATRIBUTOS ===");
        for (int i = 0; i < metodos.Count; i++)
        {
            Console.WriteLine($"  [{i + 1}] {metodos[i].Nome}");
            Console.WriteLine($"       {metodos[i].Descricao}");
        }

        Console.Write("\nEscolha (1-3): ");
        int opcao;
        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 3)
        {
            Console.Write("  Opcao invalida. Digite um numero entre 1 e 3: ");
        }

        return metodos[opcao - 1];
    }
}
