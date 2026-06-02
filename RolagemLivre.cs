public class RolagemLivre : IDistribuicaoAtributos
{
    private readonly Random _rng = new Random();

    public string Nome => "Rolagem Livre (3d6, distribui a vontade)";
    public string Descricao => "Rola 3d6 seis vezes. Voce escolhe em qual atributo colocar cada resultado.";

    public Atributos Distribuir()
    {
        List<int> rolagens = new List<int>();
        for (int i = 0; i < 6; i++)
            rolagens.Add(Rolar3d6());

        rolagens.Sort((a, b) => b.CompareTo(a));

        Console.WriteLine("\n  Valores disponiveis (do maior ao menor):");
        for (int i = 0; i < rolagens.Count; i++)
            Console.WriteLine($"    [{i + 1}] {rolagens[i]}");

        return AtribuirInterativamente(rolagens);
    }

    private int Rolar3d6()
    {
        return _rng.Next(1, 7) + _rng.Next(1, 7) + _rng.Next(1, 7);
    }

    private Atributos AtribuirInterativamente(List<int> valores)
    {
        string[] nomes = { "Forca", "Destreza", "Constituicao", "Inteligencia", "Sabedoria", "Carisma" };
        int[] resultado = new int[6];
        List<int> disponiveis = new List<int>(valores);

        for (int i = 0; i < 6; i++)
        {
            Console.Write($"\n  Valor para {nomes[i]} (disponiveis: {string.Join(", ", disponiveis)}): ");
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || !disponiveis.Contains(escolha))
            {
                Console.Write("    Valor invalido. Escolha um da lista: ");
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
