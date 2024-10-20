using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    EstrellasCollect estrellasCollect;
    [Header("Personajes")]
    public GameObject normal, ninja, gato, arcos, hisoka, gojo;
    [Header("Eventos")]
    public UnityEvent onGameOver;
    [Header("Contadores")]
    public ContadorGlobal contadorGlobal;
    public  int contadorGem = 0;
    public int contadorStar = 0;
    [Header("VFX")]
    public GameObject Destello;
    [Header("UI")]
    public TextMeshProUGUI stars, gems, gemsUI;
    public TextMeshProUGUI textoFinalGemas, textoFinalStars;
    public GameObject pausePanel;
    [Header("Jugadores")]
    public Player[] players;
    public GameObject[] playerVariants;
    [Header("Camara")]
    public CinemachineVirtualCamera virtualCamera;
    private void Start()
    {
        pausePanel.SetActive(false);
    }
    private void Update()
    {
        CargarCharacter();
        ActualizarUI();
    }
    public void Muerte()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(false);
            onGameOver.Invoke();
        }
    }
    public virtual void CargarCharacter()
    {
        //
    }
    public virtual void SumarEstrellas(int cantidad)
    {
        contadorStar += cantidad;
    }
    public virtual void SumarGemas(int cantidad)
    {
        contadorGem += cantidad;
    }
    public virtual void ActualizarUI()
    {
        //
    }
    public virtual void _SeguirVariantes()
    {
        //
    }
    public virtual void Pausa()
    {
        //
    }
    public virtual void Despausa()
    {
        //
    }
}