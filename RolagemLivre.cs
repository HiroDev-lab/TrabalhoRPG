public class RolagemLivre : IDistribuicaoAtributos
{
    private readonly Random _rng = new Random();

    public string Nome => "Rolagem Livre (4d6 descarta menor, distribui à vontade)";
    public string Descricao => "Rola 4d6 sete vezes, descarta o menor dado de cada rolagem e o pior total. Você escolhe onde colocar cada valor.";

    public Atributos Distribuir()
    {
        List<int> rolagens = new List<int>();

        for (int i = 0; i < 7; i++)
        {
            rolagens.Add(Rolar4d6DescartaMenor());
        }

        rolagens.Sort((a, b) => b.CompareTo(a));
        rolagens.RemoveAt(rolagens.Count - 1);

        Console.WriteLine("\nValores disponiveis para distribuir (do maior ao menor):");
        for (int i = 0; i < rolagens.Count; i++)
        {
            Console.WriteLine($"  [{i + 1}] {rolagens[i]}");
        }

        return AtribuirInterativamente(rolagens);
    }

    private int Rolar4d6DescartaMenor()
    {
        int[] dados = { _rng.Next(1, 7), _rng.Next(1, 7), _rng.Next(1, 7), _rng.Next(1, 7) };
        return dados.Sum() - dados.Min();
    }

    private Atributos AtribuirInterativamente(List<int> valores)
    {
        string[] nomes = { "Forca", "Destreza", "Constituicao", "Inteligencia", "Sabedoria", "Carisma" };
        int[] resultado = new int[6];
        List<int> disponiveis = new List<int>(valores);

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"\nValor para {nomes[i]} (disponiveis: {string.Join(", ", disponiveis)}): ");
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || !disponiveis.Contains(escolha))
            {
                Console.Write("  Valor invalido. Escolha um da lista: ");
            }
            resultado[i] = escolha;
            disponiveis.Remove(escolha);
        }

        return new Atributos
        {
            Forca        = resultado[0],
            Destreza     = resultado[1],
            Constituicao = resultado[2],
            Inteligencia = resultado[3],
            Sabedoria    = resultado[4],
            Carisma      = resultado[5],
        };
    }
}
