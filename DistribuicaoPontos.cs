public class DistribuicaoPontos : IDistribuicaoAtributos
{
    private const int VALOR_BASE    = 8;
    private const int PONTOS_TOTAIS = 27;
    private const int VALOR_MAXIMO  = 15;

    public string Nome => "Distribuicao por Pontos (Point Buy)";
    public string Descricao => $"Cada atributo começa em {VALOR_BASE}. Distribua {PONTOS_TOTAIS} pontos (maximo {VALOR_MAXIMO} por atributo).";

    public Atributos Distribuir()
    {
        string[] nomes = { "Forca", "Destreza", "Constituicao", "Inteligencia", "Sabedoria", "Carisma" };
        int[] valores = new int[6];

        for (int i = 0; i < 6; i++)
            valores[i] = VALOR_BASE;

        int pontosRestantes = PONTOS_TOTAIS;

        Console.WriteLine($"\n  Todos os atributos comecam em {VALOR_BASE}.");
        Console.WriteLine($"  Voce tem {PONTOS_TOTAIS} pontos para distribuir (maximo {VALOR_MAXIMO} por atributo).\n");

        for (int i = 0; i < 6; i++)
        {
            int maxAdicionavel = Math.Min(pontosRestantes, VALOR_MAXIMO - valores[i]);
            Console.Write($"  {nomes[i],15} (atual: {valores[i]}, restam: {pontosRestantes} pts, pode add ate {maxAdicionavel}): ");

            int adicionar;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out adicionar))
                {
                    Console.Write("    Numero invalido: ");
                    continue;
                }
                if (adicionar < 0)
                {
                    Console.Write("    Nao pode ser negativo: ");
                    continue;
                }
                if (adicionar > pontosRestantes)
                {
                    Console.Write($"    So restam {pontosRestantes} pontos: ");
                    continue;
                }
                if (valores[i] + adicionar > VALOR_MAXIMO)
                {
                    Console.Write($"    Maximo permitido e {VALOR_MAXIMO}: ");
                    continue;
                }
                break;
            }

            valores[i] += adicionar;
            pontosRestantes -= adicionar;
        }

        if (pontosRestantes > 0)
            Console.WriteLine($"\n  Atencao: {pontosRestantes} ponto(s) nao foram utilizados.");

        return new Atributos
        {
            Forca        = valores[0],
            Destreza     = valores[1],
            Constituicao = valores[2],
            Inteligencia = valores[3],
            Sabedoria    = valores[4],
            Carisma      = valores[5],
        };
    }
}
