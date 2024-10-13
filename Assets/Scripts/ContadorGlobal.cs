using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorGlobal : MonoBehaviour
{
    private int contadorGem = 0;
    private int contadorStar = 0;
    public TextMeshProUGUI stars, gems, gemsUI;
    public void SumarGemas(int cantidad)
    {
        contadorGem += cantidad;
    }
    public void SumarEstrellas(int cantidad)
    {
        contadorStar += cantidad;
    }
    private void Update()
    {
        stars.text = "+" + contadorStar.ToString();
        gems.text = "+" + contadorGem.ToString();
        gemsUI.text = contadorGem.ToString();
    }
}