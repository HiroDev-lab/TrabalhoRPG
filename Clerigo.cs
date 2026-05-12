public class Clerigo : ClassePersonagem
{
    public override string Nome => "Clerigo";

    public override string Descricao =>
        "Servo de uma divindade. Equilibra combate e magia sagrada, " +
        "essencial para curar aliados e enfrentar mortos-vivos.";

    public override List<string> Caracteristicas => new List<string>
    {
        "Conjura magias divinas de cura, protecao e utilidade",
        "Habilidade Turn Undead: afasta ou destroi mortos-vivos",
        "Proficiencia com armaduras e armas sem fio (macas, martelos)",
        "Pode usar escudo para aumentar a defesa",
        "Acesso a feiticos de cura exclusivos que o Mago nao tem",
    };

    public override int DadoDeVida => 8;
}
