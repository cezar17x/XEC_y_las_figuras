using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Hexagono : MonoBehaviour
{
    public GameObject objeto; // El objeto que caerá
    public float alturaInicial = 10f; // Altura desde la que el objeto caerá
    public float tiempoAdvertencia = 2f; // Tiempo que dura la advertencia en pantalla
    public CanvasGroup advertenciaCanvas;

    private Rigidbody2D rb;

    void Start()
    {
        // Inicializamos la posición del objeto en la altura especificada
        objeto.transform.position = new Vector3(objeto.transform.position.x, alturaInicial, objeto.transform.position.z);

        advertenciaCanvas.alpha = 0f;
        rb = objeto.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // Llamamos a la advertencia y el objeto caerá después
        StartCoroutine(MostrarAdvertenciaYDejarCaer());
        
    }

    IEnumerator MostrarAdvertenciaYDejarCaer()
    {
        advertenciaCanvas.alpha = 1.0f;
        yield return new WaitForSeconds(tiempoAdvertencia);
        advertenciaCanvas.alpha = 0f;
        rb.isKinematic = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destruir Player;
        }
    }
}