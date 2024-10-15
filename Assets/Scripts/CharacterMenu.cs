using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public CharacterManager characterManager; // Asignado desde el inspector
    public Button unlockButton;
    public Button equipButton;
    public TextMeshProUGUI statusText;

    void Start()
    {
        equipButton.interactable = true;
        unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "DESBLOQUEAR";
        equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "EQUIPAR";
        UpdateUI();
    }
    private void Update()
    {
        UpdateUI();
    }
    // Actualiza la UI con el estado del personaje
    void UpdateUI()
    {
        if (characterManager.IsCharacterUnlocked())
        {
            unlockButton.interactable = false;
            statusText.text = "Desbloqueado";

            if (characterManager.IsCharacterEquipped())
            {
                equipButton.interactable = false;
                statusText.text += " y Equipado";
            }
            else
            {
                equipButton.interactable = true;
            }
        }
        else
        {
            unlockButton.interactable = true;
            equipButton.interactable = false;
            statusText.text = "Bloqueado";
        }
    }

    // Llamar cuando el botón de desbloqueo es presionado
    public void OnUnlockButtonPressed()
    {
        characterManager.UnlockCharacter();
        UpdateUI();
    }

    // Llamar cuando el botón de equipar es presionado
    public void OnEquipButtonPressed()
    {
        characterManager.EquipCharacter();
        UpdateUI();
    }
}