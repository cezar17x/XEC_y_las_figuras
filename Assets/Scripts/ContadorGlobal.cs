
public class ContadorGlobal : GameManager
{
    public override void SumarGemas(int cantidad)
    {
        base.SumarGemas(cantidad);
    }
    public override void SumarEstrellas(int cantidad)
    {
        base.SumarEstrellas(cantidad);
    }
    public override void ActualizarUI()
    {
        stars.text = "+" + contadorStar.ToString();
        gems.text = "+" + contadorGem.ToString();
        gemsUI.text = contadorGem.ToString();
        ContadorFinal();
    }
}