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
