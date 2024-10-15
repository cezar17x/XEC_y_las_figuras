using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommerceSystem : MonoBehaviour
{
    private const string GemsKey = "Gems";

    // Cargar gemas al iniciar el juego
    private void Start()
    {
        LoadGems();
    }

    // M�todo para recolectar gemas
    public void CollectGems(int amount)
    {
        int currentGems = PlayerPrefs.GetInt(GemsKey, 0);
        currentGems += amount;
        PlayerPrefs.SetInt(GemsKey, currentGems);
        PlayerPrefs.Save();
    }

    // M�todo para gastar gemas al desbloquear algo
    public bool SpendGems(int amount)
    {
        int currentGems = PlayerPrefs.GetInt(GemsKey, 0);
        if (currentGems >= amount)
        {
            currentGems -= amount;
            PlayerPrefs.SetInt(GemsKey, currentGems);
            PlayerPrefs.Save();
            return true; // �xito al gastar gemas
        }
        return false; // No hay suficientes gemas
    }

    // Cargar gemas desde PlayerPrefs
    private void LoadGems()
    {
        int currentGems = PlayerPrefs.GetInt(GemsKey, 0);
        Debug.Log("Gemas cargadas: " + currentGems);
    }

    // M�todo para obtener la cantidad actual de gemas
    public int GetGems()
    {
        return PlayerPrefs.GetInt(GemsKey, 0);
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll(); // Elimina todos los datos guardados en PlayerPrefs
        PlayerPrefs.Save(); // Guarda los cambios
        Debug.Log("Datos reseteados.");
    }
}