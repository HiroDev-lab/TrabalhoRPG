public class RolagemSequencial : IDistribuicaoAtributos
{
    private readonly Random _rng = new Random();

    public string Nome => "Rolagem Sequencial (3d6 em ordem)";
    public string Descricao => "Rola 3d6 seis vezes seguidas, em ordem fixa. Sem escolha de onde colocar.";

    public Atributos Distribuir()
    {
        Atributos atributos = new Atributos
        {
            Forca        = Rolar3d6(),
            Destreza     = Rolar3d6(),
            Constituicao = Rolar3d6(),
            Inteligencia = Rolar3d6(),
            Sabedoria    = Rolar3d6(),
            Carisma      = Rolar3d6(),
        };

        Console.WriteLine("\n  [Dados rolados automaticamente na ordem]");
        return atributos;
    }

    private int Rolar3d6()
    {
        return _rng.Next(1, 7)
             + _rng.Next(1, 7)
             + _rng.Next(1, 7);
    }
}
