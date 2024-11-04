using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

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
    public int[] nivelesConBomba;
    #region
    private float tiempoEntreTaps = 0.3f, ultimoTap = 0f;
    float tiempoPulsacionActual = 0f;
    bool dedoPulsado = false;
    #endregion
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (Array.Exists(nivelesConBomba, nivel => nivel == currentScene.buildIndex))
        {
            Bombardear();
        }
        Disparar();
    }
    void Disparar()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Time.time - ultimoTap < tiempoEntreTaps && municionActual > 0)
            {
                DispararRaycastConProyectil();
            }
            ultimoTap = Time.time;
        }
    }
    void Bombardear()
    {
        dedoPulsado = (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary) ? true : false;
        if (dedoPulsado)
        {
            tiempoPulsacionActual += Time.deltaTime;
        }
        else
        {
            tiempoPulsacionActual = 0f;
        }
        if (tiempoPulsacionActual >= tiempoPulsacionRequerido)
        {
            InstanciarObjeto();
        }
        imagenLlenadoRadial.fillAmount = tiempoPulsacionActual / tiempoPulsacionRequerido;
    }
    public virtual void RecogerMunicion(int cantidad)
    {
        municionActual = Mathf.Clamp(municionActual + cantidad, 0, municionMaxima);
        ActualizarUI(municionActual);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            RecogerMunicion(1);
            Destroy(collision.gameObject);
        }
    }
    void DispararRaycastConProyectil()
    {

        if (municionActual > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(puntoDisparo.position, puntoDisparo.right, distanciaDisparo, layerObjetivo);
            if (hit.collider != null)
            {
                GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);
                Vector2 direccionObjetivo = (hit.point - (Vector2)puntoDisparo.position).normalized;
                Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
                rb.velocity = direccionObjetivo * velocidadProyectil;
                StartCoroutine(DestruirTime(proyectil));
                onDisparo.Invoke();
            }
            else
            {
                Debug.Log("No se impactó con ningún objeto en el LayerMask.");
            }
            municionActual--;
            ActualizarUI(municionActual);
        }
    }
    IEnumerator DestruirTime(GameObject bala)
    {
        yield return new WaitForSeconds(1);
        Destroy(bala);
        StopCoroutine(DestruirTime(bala));
    }
    void ActualizarUI(int cantidad)
    {
        contadorBalas.text = cantidad.ToString();
    }
    void InstanciarObjeto()
    {
        Instantiate(bombaPrefab, transform.position, Quaternion.identity);
        tiempoPulsacionActual = 0f;
    }
}
