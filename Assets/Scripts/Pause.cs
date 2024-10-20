using UnityEngine;

public class Pause : GameManager
{
    private bool isPaused = false;
    public override void Pausa()
    {
        if (!isPaused)
        {
            isPaused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public override void Despausa()
    {
        if (isPaused)
        {
            isPaused = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}