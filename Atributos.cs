public class Atributos
{
    public int Forca { get; set; }
    public int Destreza { get; set; }
    public int Constituicao { get; set; }
    public int Inteligencia { get; set; }
    public int Sabedoria { get; set; }
    public int Carisma { get; set; }

    public static int CalcularModificador(int valor)
    {
        if (valor == 3)  return -3;
        if (valor <= 5)  return -2;
        if (valor <= 8)  return -1;
        if (valor <= 12) return  0;
        if (valor <= 15) return +1;
        if (valor <= 17) return +2;
        return +3;
    }

    public void Exibir()
    {
        Console.WriteLine("\n=== ATRIBUTOS ===");
        MostrarLinha("FOR (Forca)",        Forca);
        MostrarLinha("DES (Destreza)",     Destreza);
        MostrarLinha("CON (Constituicao)", Constituicao);
        MostrarLinha("INT (Inteligencia)", Inteligencia);
        MostrarLinha("SAB (Sabedoria)",    Sabedoria);
        MostrarLinha("CAR (Carisma)",      Carisma);
    }

    private void MostrarLinha(string nome, int valor)
    {
        int mod = CalcularModificador(valor);
        string sinal = mod >= 0 ? "+" : "";
        Console.WriteLine($"  {nome,-20}: {valor,2}   modificador: {sinal}{mod}");
    }
}
