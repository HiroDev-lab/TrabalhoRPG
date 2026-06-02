public class DistribuicaoPontos : IDistribuicaoAtributos
{
    private const int PONTOS_TOTAIS = 72;
    private const int VALOR_MINIMO  = 3;
    private const int VALOR_MAXIMO  = 18;

    public string Nome => "Distribuicao por Pontos";
    public string Descricao => $"Distribua {PONTOS_TOTAIS} pontos entre os 6 atributos (minimo {VALOR_MINIMO}, maximo {VALOR_MAXIMO} cada).";

    public Atributos Distribuir()
    {
        string[] nomes = { "Forca", "Destreza", "Constituicao", "Inteligencia", "Sabedoria", "Carisma" };
        int[] valores = new int[6];
        int pontosRestantes = PONTOS_TOTAIS;

        Console.WriteLine($"\n  Distribua {PONTOS_TOTAIS} pontos entre os atributos.");
        Console.WriteLine($"  Cada atributo deve ter entre {VALOR_MINIMO} e {VALOR_MAXIMO}.\n");

        for (int i = 0; i < 6; i++)
        {
            int atributosRestantes = 6 - i;
            int minimoReservado    = (atributosRestantes - 1) * VALOR_MINIMO;
            int maxPermitido       = Math.Min(VALOR_MAXIMO, pontosRestantes - minimoReservado);

            Console.Write($"  {nomes[i],15} (restam {pontosRestantes} pts, min {VALOR_MINIMO}, max {maxPermitido}): ");

            int valor;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    Console.Write("    Numero invalido: ");
                    continue;
                }
                if (valor < VALOR_MINIMO)
                {
                    Console.Write($"    Minimo e {VALOR_MINIMO}: ");
                    continue;
                }
                if (valor > maxPermitido)
                {
                    Console.Write($"    Maximo permitido e {maxPermitido}: ");
                    continue;
                }
                break;
            }

            valores[i]      = valor;
            pontosRestantes -= valor;
        }

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
