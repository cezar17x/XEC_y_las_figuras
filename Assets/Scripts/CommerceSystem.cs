using UnityEngine;

public class CommerceSystem : GameManager
{
    // Método para recolectar gemas
    public override void CollectGems(int amount)
    {
        int currentGems = PlayerPrefs.GetInt(GemsKey, 0);
        currentGems += amount;
        PlayerPrefs.SetInt(GemsKey, currentGems);
        PlayerPrefs.Save();
    }

    // Método para gastar gemas al desbloquear algo
    public override bool SpendGems(int amount)
    {
        int currentGems = PlayerPrefs.GetInt(GemsKey, 0);
        if (currentGems >= amount)
        {
            currentGems -= amount;
            PlayerPrefs.SetInt(GemsKey, currentGems);
            PlayerPrefs.Save();
            return true; // Éxito al gastar gemas
        }
        return false; // No hay suficientes gemas
    }

    // Cargar gemas desde PlayerPrefs
    public override  void LoadGems()
    {
        int currentGems = PlayerPrefs.GetInt(GemsKey, 0);
        Debug.Log("Gemas cargadas: " + currentGems);
    }

    // Método para obtener la cantidad actual de gemas
    public override int GetGems()
    {
        return base.GetGems(); 
    }
}