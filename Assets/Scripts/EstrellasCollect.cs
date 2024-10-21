using UnityEngine;

public class EstrellasCollect : GameManager
{
    // Método para recolectar estrellas
    public override void CollectStars(int amount)
    {
        int currentStars = PlayerPrefs.GetInt(base.StarKey, 0);
        currentStars += amount;
        PlayerPrefs.SetInt(base.StarKey, currentStars);
        PlayerPrefs.Save();
    }
    // Método para gastar estrellas al desbloquear algo
    public override bool SpendStars(int amount)
    {
        int currentStars = PlayerPrefs.GetInt(base.StarKey, 0);
        if (currentStars >= amount)
        {
            currentStars -= amount;
            PlayerPrefs.SetInt(base.StarKey, currentStars);
            PlayerPrefs.Save();
            return true; // Éxito al gastar estrellas
        }
        return false; // No hay suficientes estrellas
    }
    // Cargar estrellas desde PlayerPrefs
    public override void LoadStars()
    {
        int currentStars = PlayerPrefs.GetInt(base.StarKey, 0);
        Debug.Log("Estrellas cargadas: " + currentStars);
    }
    // Método para obtener la cantidad actual de gemas
    public override int GetStars()
    {
        return PlayerPrefs.GetInt(base.StarKey, 0);
    }
}