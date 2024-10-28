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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Si el tiempo entre el último toque y el toque actual es menor al tiempo permitido para doble tap
            if (Time.time - ultimoTap < tiempoEntreTaps && base.municionActual > 0)
            {
                DispararRaycastConProyectil();
            }
            ultimoTap = Time.time; // Actualizar el tiempo del último toque
        }
    }
    void DispararRaycastConProyectil()
    {
        
        if (base.municionActual > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(base.puntoDisparo.position, base.puntoDisparo.right, base.distanciaDisparo, base.layerObjetivo);
            if (hit.collider != null)
            {
                GameObject proyectil = Instantiate(base.proyectilPrefab, base.puntoDisparo.position, Quaternion.identity);
                Vector2 direccionObjetivo = (hit.point - (Vector2)base.puntoDisparo.position).normalized;
                Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
                rb.velocity = direccionObjetivo * base.velocidadProyectil;
                StartCoroutine(DestruirTime(proyectil));
                base.onDisparo.Invoke(); 
            }
            else
            {
                Debug.Log("No se impactó con ningún objeto en el LayerMask.");
            }
            base.municionActual--;
            ActualizarUI(base.municionActual);
        }
    }
    IEnumerator DestruirTime(GameObject bala)
    {
        yield return new WaitForSeconds(1);
        Destroy(bala.gameObject);
        StopCoroutine(DestruirTime(bala));
    }
    public override void RecogerMunicion(int cantidad)
    {
        base.municionActual = Mathf.Clamp(base.municionActual + cantidad, 0, municionMaxima);
        ActualizarUI(base.municionActual);
    }
     public void ActualizarUI(int cantidad)
     {
        contadorBalas.text = cantidad.ToString();
     }
}