using System.Collections;
using UnityEngine;

public class Hexagono : Enemy
{
    public Rigidbody2D rb;
    public GameObject objeto;
    public float alturaInicial = 10f;
    public float tiempoAdvertencia = 2f;
    public CanvasGroup advertenciaCanvas;
    public override void Start()
    {
        base.Start();
        Caer();
    }
    private void Caer()
    {
        // Inicializamos la posici�n del objeto en la altura especificada
        objeto.transform.position = new Vector3(objeto.transform.position.x, alturaInicial, objeto.transform.position.z);

        advertenciaCanvas.alpha = 0f;
        rb = objeto.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // Llamamos a la advertencia y el objeto caer� despu�s
        StartCoroutine(MostrarAdvertenciaYDejarCaer());
    }
    IEnumerator MostrarAdvertenciaYDejarCaer()
    {
        advertenciaCanvas.alpha = 1.0f;
        yield return new WaitForSeconds(tiempoAdvertencia);
        advertenciaCanvas.alpha = 0f;
        rb.isKinematic = false;
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}