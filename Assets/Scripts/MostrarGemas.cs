
public class MostrarGemas : GameManager
{
    public void ContadorFinal()
    {
        int currentGems = FindObjectOfType<CommerceSystem>().GetGems();
        textoFinalGemas.text = currentGems.ToString();
        int currentStars = FindAnyObjectByType<EstrellasCollect>().GetStars();
        textoFinalStars.text = currentStars.ToString();
    }
}