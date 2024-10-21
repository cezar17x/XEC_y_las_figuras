using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Variables de Disparo")]
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float velocidadProyectil = 10f;
    public int municionActual = 6, municionMaxima = 6, contador = 0;
    public LayerMask layerObjetivo;
    public float distanciaDisparo = 100f;
    public bool puedeDisparar = false;
    public TextMeshProUGUI contadorBalas;
    public UnityEvent onDisparo;

    [Header("Variables de Deslizar")]
    public bool enableSlide;
    public UnityEvent onRightSlide, onLeftSlide, onUpSlide, onDownSlide;

    [Header("Variables de Bombardero")]
    public GameObject bombaPrefab;
    public Image imagenLlenadoRadial;
    public float tiempoPulsacionRequerido = 5f;
    public bool puedeBombardear = false;
    void Update()
    {
        Disparar();
        Deslizar();
        Bombardear();
    }
    // Métodos virtuales para que las clases derivadas puedan sobreescribir
    public virtual void Disparar() {  }

    public virtual void Deslizar() { }

    public virtual void Bombardear() { }
}
