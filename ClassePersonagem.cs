public abstract class ClassePersonagem
{
    public abstract string Nome { get; }
    public abstract string Descricao { get; }
    public abstract List<string> Caracteristicas { get; }
    public abstract int DadoDeVida { get; }

    public int CalcularPontosDeVida(int modificadorCon)
    {
        Random rng = new Random();
        int rolagem = rng.Next(1, DadoDeVida + 1);
        int hp = rolagem + modificadorCon;
        return Math.Max(hp, 1);
    }

    public void Exibir()
    {
        Console.WriteLine($"\n=== CLASSE: {Nome.ToUpper()} ===");
        Console.WriteLine($"  {Descricao}");
        Console.WriteLine($"  Dado de Vida: d{DadoDeVida}");
        Console.WriteLine("  Caracteristicas:");
        foreach (string c in Caracteristicas)
        {
            Console.WriteLine($"    - {c}");
        }
    }
}
