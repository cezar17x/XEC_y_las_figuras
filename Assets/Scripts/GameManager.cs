using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Personajes")]
    public GameObject normal, ninja, gato, arcos, hisoka, gojo;
    [Header("Eventos")]
    public UnityEvent onGameOver;
    [Header("Contadores")]
    public int contadorGem = 0;
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
    [Header("Enemigos")]
    public Enemy[] enemigos;
    [HideInInspector] public string StarKey = "Stars";
    [HideInInspector] public string GemsKey = "Gems";
    void Start()
    {
        pausePanel.SetActive(false);
        foreach (Enemy enemy in enemigos)
        {
            enemy.currentLife = enemy.maxLife;
            enemy.transform.position = enemy.tilemapFlecha.GetCellCenterWorld(enemy.posicionInicial);
        }
        LoadStars();
        LoadGems();
    }
    void Update()
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
    public virtual void CargarCharacter() { }
    public virtual void SumarEstrellas(int cantidad)
    {
        contadorStar += cantidad;
    }
    public virtual void SumarGemas(int cantidad)
    {
        contadorGem += cantidad;
    }
    public virtual void ActualizarUI() { }
    public virtual void SeguirVariantes1() { }
    public virtual void Pausa() { }
    public virtual void Despausa() { }
    public virtual int GetStars()
    {
        return PlayerPrefs.GetInt(StarKey, 0);
    }
    public virtual void CollectStars(int amount) { }
    public virtual void LoadGems() { }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Datos reseteados.");
    }
    // M�todo para obtener la cantidad actual de gemas
    public virtual int GetGems()
    {
        return PlayerPrefs.GetInt(GemsKey, 0);
    }
    // Cargar estrellas desde PlayerPrefs
    public virtual void LoadStars()
    {
        int currentStars = PlayerPrefs.GetInt(StarKey, 0);
        Debug.Log("Estrellas cargadas: " + currentStars);
    }
    // M�todo para recolectar gemas
    public virtual void CollectGems(int amount)
    {
        int currentGems = PlayerPrefs.GetInt(GemsKey, 0);
        currentGems += amount;
        PlayerPrefs.SetInt(GemsKey, currentGems);
        PlayerPrefs.Save();
    }
    public virtual  bool SpendGems(int amount)
    {
        int currentGems = PlayerPrefs.GetInt(GemsKey, 0);
        if (currentGems >= amount)
        {
            currentGems -= amount;
            PlayerPrefs.SetInt(GemsKey, currentGems);
            PlayerPrefs.Save();
            return true; // �xito al gastar gemas
        }
        return false; // No hay suficientes gemas
    }
    public void ContadorFinal()
    {
        int currentGems = GetGems();
        textoFinalGemas.text = currentGems.ToString();
        int currentStars = GetStars();
        textoFinalStars.text = currentStars.ToString();
    }
    // M�todo para gastar estrellas 
    public virtual bool SpendStars(int amount)
    {
        int currentStars = PlayerPrefs.GetInt(StarKey, 0);
        if (currentStars >= amount)
        {
            currentStars -= amount;
            PlayerPrefs.SetInt(StarKey, currentStars);
            PlayerPrefs.Save();
            return true; // �xito al gastar estrellas
        }
        return false; // No hay suficientes estrellas
    }
}