using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DisparoTouch : Player
{
    private float tiempoEntreTaps = 0.3f, ultimoTap = 0f;
    public override void Disparar()
    {
        base.Disparar();
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

     public void ActualizarUI(int cantidad)
     {
        contadorBalas.text = cantidad.ToString();
     }
}