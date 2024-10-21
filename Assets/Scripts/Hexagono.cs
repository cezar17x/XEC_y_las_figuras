using System.Collections;
using UnityEngine;

public class Hexagono : Enemy
{
    public string _name;
    public Hexagono(string name): base(name)
    {
        _name = name;
    }
    public override void Start()
    {
        base.Start();
    }
    public override void Caer()
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
    public override void TomaDaño(int daño)
    {
        vidaActual -= daño;
        if (vidaActual > 0)
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity);
        }
        else
        {
            onMuerte.Invoke();
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 1);
        }
    }
}