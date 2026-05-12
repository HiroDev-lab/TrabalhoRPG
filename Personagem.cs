public class Personagem
{
    public string Nome { get; private set; }
    public ClassePersonagem Classe { get; private set; }
    public Atributos Atributos { get; private set; }
    public int PontosDeVida { get; private set; }

    public Personagem(string nome, ClassePersonagem classe, Atributos atributos)
    {
        Nome      = nome;
        Classe    = classe;
        Atributos = atributos;

        int modCon = Atributos.CalcularModificador(atributos.Constituicao);
        PontosDeVida = classe.CalcularPontosDeVida(modCon);
    }

    public void ExibirFicha()
    {
        Console.WriteLine("\n==========================================");
        Console.WriteLine($"  PERSONAGEM: {Nome}");
        Console.WriteLine("==========================================");
        Classe.Exibir();
        Atributos.Exibir();

        int modCon = Atributos.CalcularModificador(Atributos.Constituicao);
        string sinal = modCon >= 0 ? "+" : "";

        Console.WriteLine($"\n  HP (Pontos de Vida): {PontosDeVida}");
        Console.WriteLine($"  Formula: 1d{Classe.DadoDeVida} + modificador CON ({sinal}{modCon}), minimo 1");
        Console.WriteLine("==========================================");
    }
}
