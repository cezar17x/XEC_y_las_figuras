using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public GameObject canvasNextLevel;
    public UnityEvent onTerminar;
    public LevelManager levelManager;
    private void Start()
    {
        canvasNextLevel.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvasNextLevel.SetActive(true);
            collision.gameObject.SetActive(false);
            levelManager.CompleteLevel(SceneManager.GetActiveScene().buildIndex);
            onTerminar.Invoke();
        }
    }
}