using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellasCollect : MonoBehaviour
{
    private const string StarKey = "Stars";
    private void Start()
    {
        LoadStars();
    }
    // Método para recolectar estrellas
    public void CollectStars(int amount)
    {
        int currentStars = PlayerPrefs.GetInt(StarKey, 0);
        currentStars += amount;
        PlayerPrefs.SetInt(StarKey, currentStars);
        PlayerPrefs.Save();
    }
    // Método para gastar estrellas al desbloquear algo
    public bool SpendStars(int amount)
    {
        int currentStars = PlayerPrefs.GetInt(StarKey, 0);
        if (currentStars >= amount)
        {
            currentStars -= amount;
            PlayerPrefs.SetInt(StarKey, currentStars);
            PlayerPrefs.Save();
            return true; // Éxito al gastar estrellas
        }
        return false; // No hay suficientes estrellas
    }
    // Cargar estrellas desde PlayerPrefs
    private void LoadStars()
    {
        int currentStars = PlayerPrefs.GetInt(StarKey, 0);
        Debug.Log("Estrellas cargadas: " + currentStars);
    }
    // Método para obtener la cantidad actual de gemas
    public int GetStars()
    {
        return PlayerPrefs.GetInt(StarKey, 0);
    }
}