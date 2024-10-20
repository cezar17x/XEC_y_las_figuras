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

    [Header("Variable de Bombardero")]
    public GameObject objetoAInstanciar;
    public Image imagenLlenadoRadial;
    public float tiempoPulsacionRequerido = 5f;
    public bool puedeBombardear = false;

    // Métodos virtuales para que las clases derivadas puedan sobreescribir
    public virtual void Disparar()
    {
        //Debug.Log("Disparar desde Player");
    }

    public virtual void Deslizar()
    {
        //Debug.Log("Deslizar desde Player");
    }

    public virtual void Bombardear()
    {
        //Debug.Log("Bombardear desde Player");
    }
}
