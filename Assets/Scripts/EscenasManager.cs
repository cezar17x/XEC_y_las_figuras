using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasManager : MonoBehaviour
{
    public void Inicio()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;  
    }
    public void SeleccionDeNiveles()
    {
        SceneManager.LoadScene(8);
    }
    public void Tienda()
    {
        SceneManager.LoadScene(9);
        Time.timeScale = 1;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}