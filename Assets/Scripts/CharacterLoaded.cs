using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterLoaded : MonoBehaviour
{
    public GameObject[] characters;

    void Start()
    {
        LoadEquippedCharacter();
    }

    void LoadEquippedCharacter()
    {
        string equippedCharacterID = PlayerPrefs.GetString("EquippedCharacter", "");

        foreach (GameObject character in characters)
        {
            if (character.name == equippedCharacterID)
            {
                PlayerPrefs.GetString("EquippedCharacter",character.name);
            }
        }
    }
}