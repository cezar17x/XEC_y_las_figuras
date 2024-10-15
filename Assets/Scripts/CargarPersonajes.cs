using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CargarPersonajes : MonoBehaviour
{
    public GameObject normal, ninja, gato, arcos, hisoka, gojo;
    private void Update()
    {
        bool normalstr = PlayerPrefs.GetString("EquippedCharacter", "") == "Normal";
        bool ninjastr = PlayerPrefs.GetString("EquippedCharacter", "") == "Ninja";
        bool gojostr = PlayerPrefs.GetString("EquippedCharacter", "") == "Gojo";
        bool gatostr = PlayerPrefs.GetString("EquippedCharacter", "") == "Gato";
        bool arcosstr = PlayerPrefs.GetString("EquippedCharacter", "") == "Arcos";
        bool hisokastr = PlayerPrefs.GetString("EquippedCharacter", "") == "Hisoka";
        if (normalstr)
        {

            normal.SetActive(true);
            DesactivarOtros(gojo, hisoka, arcos, ninja, gato);
        }
        else if (ninjastr)
        {
            if (!ninja.activeInHierarchy)
            {
                return;
            }
            ninja.SetActive(true);
            DesactivarOtros(gojo, hisoka, arcos, normal, gato);
        }
        else if (gojostr)
        {
            if (!gojo.activeInHierarchy)
            {
                return;
            }
            gojo.SetActive(true);
            DesactivarOtros(ninja, hisoka, arcos, normal, gato);
        }
        else if (gatostr)
        {
            if (!gato.activeInHierarchy)
            {
                return;
            }
            gato.SetActive(true);
            DesactivarOtros(gojo, hisoka, arcos, normal, ninja);
        }
        else if (arcosstr)
        {
            if (!arcos.activeInHierarchy)
            {
                return;
            }
            arcos.SetActive(true);
            DesactivarOtros(gojo, hisoka, gato, normal, ninja);
        }
        else if (hisokastr)
        {
            if (!hisoka.activeInHierarchy)
            {
                return;
            }
            hisoka.SetActive(true);
            DesactivarOtros(gojo, arcos, gato, normal, ninja);
        }
    }
    void DesactivarOtros(params GameObject[] otros)
    {
        for (int i = 0; i < otros.Length; i++)
        {
            otros[i].SetActive(false);
        }
    }
}