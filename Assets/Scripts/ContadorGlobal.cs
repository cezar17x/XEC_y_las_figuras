
public class ContadorGlobal : GameManager
{
    MostrarGemas mostrarFinal;
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
        mostrarFinal = new MostrarGemas();
        stars.text = "+" + contadorStar.ToString();
        gems.text = "+" + contadorGem.ToString();
        gemsUI.text = contadorGem.ToString();
        mostrarFinal.ContadorFinal();
    }
}