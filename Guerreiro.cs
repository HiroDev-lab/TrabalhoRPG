public class Guerreiro : ClassePersonagem
{
    public override string Nome => "Guerreiro";

    public override string Descricao =>
        "Especialista em combate. Usa qualquer arma e armadura, " +
        "sendo o principal protetor do grupo na linha de frente.";

    public override List<string> Caracteristicas => new List<string>
    {
        "Proficiencia com todas as armas e armaduras do jogo",
        "Ataque multiplo a partir do nivel 6 (dois ataques/rodada)",
        "Maior bonus de ataque entre todas as classes",
        "Pode usar escudo sem nenhuma penalidade",
        "Pode se especializar em uma arma (+1 no dano com ela)",
    };

    public override int DadoDeVida => 10;
}
