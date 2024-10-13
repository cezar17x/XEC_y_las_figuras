using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    public Image[] candados;
    
    void Start()
    {
        for (int i = 0; i < candados.Length; i++)
        {
            candados[i].gameObject.SetActive(false);
        }
        int highestUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Por defecto, el nivel 1 está desbloqueado

        // Desbloquear botones de niveles según el progreso guardado
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > highestUnlockedLevel)
            {
                levelButtons[i].interactable = false; // Bloquear el nivel
                candados[i].gameObject.SetActive(true);
            }
        }
    }

    // Método para cargar un nivel
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    // Método para llamar cuando se completa un nivel
    public void CompleteLevel(int levelIndex)
    {
        int highestUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (levelIndex >= highestUnlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelIndex + 1); // Desbloquea el siguiente nivel
        }
        for (int i = 0; i < candados.Length; i++)
        {
            candados[levelIndex++].gameObject.SetActive(false);
        }    
    }
}