public class Ladino : ClassePersonagem
{
    public override string Nome => "Ladino";

    public override string Descricao =>
        "Mestre da furtividade e astúcia. Usa as sombras e habilidades " +
        "unicas para superar inimigos sem confronto direto.";

    public override List<string> Caracteristicas => new List<string>
    {
        "Ataque Furtivo: dano extra quando o alvo esta desprevenido",
        "Ladinagem: arromba fechaduras, desativa armadilhas, furta",
        "Furtividade: se esconde em sombras e se move sem fazer barulho",
        "Evasao: sofre metade do dano de magias de area (reflexos rapidos)",
        "Proficiencia com armas e armaduras leves (mobilidade em primeiro lugar)",
    };

    public override int DadoDeVida => 6;
}
