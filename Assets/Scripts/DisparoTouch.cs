using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoTouch : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float velocidadProyectil = 10f;
    public int municionActual = 6; 
    public int municionMaxima = 6;
    public List<Image> imagenesMunicion;
    private float tiempoEntreTaps = 0.3f;
    private float ultimoTap = 0f;
    public LayerMask layerObjetivo;
    public float distanciaDisparo = 100f;
    public bool puedeDisparar = false;

    void Start()
    {
        ActualizarUI(); 
    }

    void Update()
    {
        if (!puedeDisparar) return;
        if (puedeDisparar)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Si el tiempo entre el �ltimo toque y el toque actual es menor al tiempo permitido para doble tap
                if (Time.time - ultimoTap < tiempoEntreTaps && municionActual > 0)
                {
                    DispararRaycastConProyectil();
                }
                ultimoTap = Time.time; // Actualizar el tiempo del �ltimo toque
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

                // Calcular la direcci�n hacia el objetivo
                Vector2 direccionObjetivo = (hit.point - (Vector2)puntoDisparo.position).normalized;

                
                Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
                rb.velocity = direccionObjetivo * velocidadProyectil;
                StartCoroutine(DestruirTime(proyectil));
            }
            else
            {
                //Debug.Log("No se impact� con ning�n objeto en el LayerMask.");
            }
            municionActual--;
            ActualizarUI();
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
        municionActual = Mathf.Clamp(municionActual + cantidad, 0, municionMaxima); // Aumentar la munici�n sin superar el m�ximo
        ActualizarUI();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bala"))
        {
            RecogerMunicion(1);
            Destroy(collision.gameObject);
        }
    }

    void ActualizarUI()
    {
        // Mostrar o esconder im�genes de balas dependiendo de la munici�n actual
        for (int i = 0; i < imagenesMunicion.Count; i++)
        {
            if (i < municionActual)
            {
                imagenesMunicion[i].enabled = true; 
            }
            else
            {
                imagenesMunicion[i].enabled = false;
            }
        }
    }
}