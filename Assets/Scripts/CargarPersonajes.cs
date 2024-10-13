using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CargarPersonajes : MonoBehaviour
{
    public GameObject normal, ninja, gato, arcos, hisoka, gojo;
    private void Update()
    {
        bool normalb = PlayerPrefs.GetInt("Normal") == 1;
        bool ninjab = PlayerPrefs.GetInt("Ninja") == 1;
        bool gojob = PlayerPrefs.GetInt("Gojo") == 1;
        bool gatob = PlayerPrefs.GetInt("Gato") == 1;
        bool arcosb = PlayerPrefs.GetInt("Arcos") == 1;
        bool hisokab = PlayerPrefs.GetInt("Hisoka") == 1;
        bool normalstr = PlayerPrefs.GetString("EquippedCharacter", "") == "Normal";
        bool ninjastr = PlayerPrefs.GetString("EquippedCharacter", "") == "Ninja";
        bool gojostr = PlayerPrefs.GetString("EquippedCharacter", "") == "Gojo";
        bool gatostr = PlayerPrefs.GetString("EquippedCharacter", "") == "Gato";
        bool arcosstr = PlayerPrefs.GetString("EquippedCharacter", "") == "Arcos";
        bool hisokastr = PlayerPrefs.GetString("EquippedCharacter", "") == "Hisoka";
        if (normalb && normalstr)
        {
            normal.SetActive(true);
            DesactivarOtros(gojo, hisoka, arcos, ninja, gato);
        }
        else if(ninjab && ninjastr)
        {
            ninja.SetActive(true);
            DesactivarOtros(gojo, hisoka, arcos, normal, gato);
        }
        else if (gojob && gojostr)
        {
            gojo.SetActive(true);
            DesactivarOtros(ninja, hisoka, arcos, normal, gato);
        }
        else if (gatob && gatostr)
        {
            gato.SetActive(true);
            DesactivarOtros(gojo, hisoka, arcos, normal, ninja);
        }
        else if (arcosb && arcosstr)
        {
            arcos.SetActive(true);
            DesactivarOtros(gojo, hisoka, gato, normal, ninja);
        }
        else if (hisokab && hisokastr)
        {
            hisoka.SetActive(true);
            DesactivarOtros(gojo, arcos, gato, normal, ninja);
        }
    }
    void DesactivarOtros(GameObject uno,GameObject dos,GameObject tres,GameObject cuatro,GameObject cinco)
    {
        uno.SetActive(false);
        dos.SetActive(false);
        tres.SetActive(false);
        cuatro.SetActive(false);
        cinco.SetActive(false);
    }
}