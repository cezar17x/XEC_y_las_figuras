using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MostrarGemas : MonoBehaviour
{
    public TextMeshProUGUI texto, texto2;
    private void Update()
    {
        int currentGems = FindObjectOfType<CommerceSystem>().GetGems();
        texto.text = currentGems.ToString();
        int currentStars = FindAnyObjectByType<EstrellasCollect>().GetStars();
        texto2.text = currentStars.ToString();
    }
}