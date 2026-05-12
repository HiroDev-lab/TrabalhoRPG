public class Mago : ClassePersonagem
{
    public override string Nome => "Mago";

    public override string Descricao =>
        "Estudioso das artes arcanas. Fragil em combate direto, " +
        "mas possui o maior arsenal de feiticos do jogo.";

    public override List<string> Caracteristicas => new List<string>
    {
        "Conjura magias arcanas de dano, controle e utilidade",
        "Tem acesso ao maior numero de feiticos entre todas as classes",
        "Usa grimorio: precisa memorizar feiticos todo dia ao acordar",
        "Proficiencia apenas com cajado, adaga e dardo (armas simples)",
        "Nao pode usar armaduras — elas interferem na concentracao magica",
    };

    public override int DadoDeVida => 4;
}
