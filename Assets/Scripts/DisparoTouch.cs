using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisparoTouch : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float velocidadProyectil = 10f;
    public int municionActual = 6, municionMaxima = 6, contador = 0; 
    private float tiempoEntreTaps = 0.3f;
    private float ultimoTap = 0f;
    public LayerMask layerObjetivo;
    public float distanciaDisparo = 100f;
    public bool puedeDisparar = false;
    public TextMeshProUGUI contadorBalas;

    void Start()
    {
        ActualizarUI(municionActual); 
    }
    public void CambiarVariable(bool ticket)
    {
        puedeDisparar = ticket;
    }
    void Update()
    {
        if (!puedeDisparar) return;
        if (puedeDisparar)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Si el tiempo entre el último toque y el toque actual es menor al tiempo permitido para doble tap
                if (Time.time - ultimoTap < tiempoEntreTaps && municionActual > 0)
                {
                    DispararRaycastConProyectil();
                }
                ultimoTap = Time.time; // Actualizar el tiempo del último toque
            }
        }   
    }
    void DispararRaycastConProyectil()
    {
        
        if (municionActual > 0)
        {
            
            RaycastHit2D hit = Physics2D.Raycast(puntoDisparo.position, puntoDisparo.right, distanciaDisparo, layerObjetivo);

            
            if (hit.collider != null)
            {
                //Debug.Log("Impacto en: " + hit.collider.name);

                
                GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);

                // Calcular la dirección hacia el objetivo
                Vector2 direccionObjetivo = (hit.point - (Vector2)puntoDisparo.position).normalized;

                
                Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
                rb.velocity = direccionObjetivo * velocidadProyectil;
                StartCoroutine(DestruirTime(proyectil));
            }
            else
            {
                //Debug.Log("No se impactó con ningún objeto en el LayerMask.");
            }
            municionActual--;
            ActualizarUI(municionActual);
        }
    }
    IEnumerator DestruirTime(GameObject bala)
    {
        yield return new WaitForSeconds(1);
        Destroy(bala.gameObject);
        StopCoroutine(DestruirTime(bala));
    }
    public void RecogerMunicion(int cantidad)
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

    void ActualizarUI(int cantidad)
    {
        contadorBalas.text = cantidad.ToString();
    }
}