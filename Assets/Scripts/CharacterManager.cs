using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public string characterID; // ID del personaje, único para cada uno
    public int unlockCost, unlockCostStar; // Coste en monedas para desbloquear el personaje
    public TextMeshProUGUI resultado;
    private void Start()
    {
        PlayerPrefs.GetInt(characterID, 0);
    }
    public bool IsCharacterUnlocked()
    {
        return PlayerPrefs.GetInt(characterID, 0) == 1;
    }
    public void UnlockCharacter()
    {
        int currentGems = PlayerPrefs.GetInt("Gems", 0);
        int currentStars = PlayerPrefs.GetInt("Stars", 0);

        if (currentGems >= unlockCost && !IsCharacterUnlocked())
        {
            PlayerPrefs.SetInt(characterID, 1); // Desbloquear personaje
            PlayerPrefs.SetInt("Gems", currentGems - unlockCost); // Restar el costo en monedas
            Debug.Log($"{characterID} desbloqueado!");
            resultado.text = $"{characterID} desbloqueado!";
        }
        else if (currentStars >= unlockCostStar && !IsCharacterUnlocked())
        {
            PlayerPrefs.SetInt(characterID, 1); // Desbloquear personaje
            PlayerPrefs.SetInt("Stars", currentStars - unlockCostStar); // Restar el costo en monedas
            Debug.Log($"{characterID} desbloqueado!");
            resultado.text = $"{characterID} desbloqueado!";
        }
        else
        {
            Debug.Log("No tienes suficientes monedas o ya está desbloqueado.");
            resultado.text = "No tienes suficiente o ya lo tienes";
        }
    }
    public void EquipCharacter()
    {
        if (IsCharacterUnlocked())
        {
            PlayerPrefs.SetString("EquippedCharacter", characterID);
            PlayerPrefs.SetInt(characterID, 1);
            PlayerPrefs.Save();
            Debug.Log($"{characterID} equipado.");
            resultado.text = $"{characterID} equipado";
        }
        else
        {
            Debug.Log($"{characterID} no está desbloqueado.");
            resultado.text = $"{characterID} no está desbloqueado";
        }
    }
    public bool IsCharacterEquipped()
    {
        return PlayerPrefs.GetString("EquippedCharacter", "") == characterID;
    }
}