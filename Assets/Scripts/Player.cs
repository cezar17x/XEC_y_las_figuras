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
    public TextMeshProUGUI contadorBalas;
    public UnityEvent onDisparo;
    [Header("Variables de Bombardero")]
    public GameObject bombaPrefab;
    public Image imagenLlenadoRadial;
    public float tiempoPulsacionRequerido = 5f;
    [Header("Habilidades")]
    public TouchSlide touch;
    void Update()
    {
        Disparar();
        touch.Movimiento();
        Bombardear();
    }
    // Métodos virtuales para que las clases derivadas puedan sobreescribir
    public virtual void Disparar() {  }
    public virtual void Bombardear() { }
    public virtual void RecogerMunicion(int cantidad) { }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            RecogerMunicion(1);
            Destroy(collision.gameObject);
        }
    }
}
