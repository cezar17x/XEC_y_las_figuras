using UnityEngine;

public class Flecha : Enemy
{
    public Flecha(string name): base(name){}
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
    public override void CalcularNuevaPosicion()
    {
        // Calcula la nueva posici�n basada en la direcci�n
        Vector3 targetPosition = transform.position;

        if (movingRight)
        {
            targetPosition.x += speed * Time.deltaTime;
        }
        else
        {
            targetPosition.x -= speed * Time.deltaTime;
        }

        // Mueve el enemigo hacia la nueva posici�n
        transform.position = targetPosition;
        if (transform.position.x >= tilemapFlecha.size.x - 1) // Cambia seg�n el tama�o de tu tilemap
        {
            movingRight = false; // Cambia la direcci�n a izquierda
            Quaternion rotacion = Quaternion.Euler(0f, 0f, 180f);
            root.transform.localRotation = rotacion;
        }
        else if (transform.position.x <= 0)
        {
            movingRight = true; // Cambia la direcci�n a derecha
            Quaternion rotacion = Quaternion.Euler(0f, 0f, 0f);
            root.transform.localRotation = rotacion;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            movingRight = !movingRight;
            Quaternion rotacion = Quaternion.Euler(0f, 0f, 180f);
            root.transform.localRotation = rotacion;
        }
        else if (collision.gameObject.layer == layerPared)
        {
            movingRight = !movingRight;
            Quaternion rotacion = Quaternion.Euler(0f, 0f, 180f);
            root.transform.localRotation = rotacion;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject, 2);
            //Instanciar particula de muerte;
        }
    }
    public override void TomaDa�o(int da�o)
    {
        vidaActual -= da�o;
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