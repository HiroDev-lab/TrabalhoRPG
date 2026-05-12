public interface IDistribuicaoAtributos
{
    string Nome { get; }
    string Descricao { get; }
    Atributos Distribuir();
}
