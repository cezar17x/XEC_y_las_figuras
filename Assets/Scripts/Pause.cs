using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    private bool isPaused = false;

    private void Start()
    {
        pause.SetActive(false);
    }
    public void Pausa()
    {
        if (!isPaused)
        {
            isPaused = true;
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Despausa()
    {
        if (isPaused)
        {
            isPaused = false;
            pause.SetActive(false);
            Time.timeScale = 1;
        }
    }
}