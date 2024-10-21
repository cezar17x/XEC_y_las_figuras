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
        // Calcula la nueva posición basada en la dirección
        Vector3 targetPosition = transform.position;

        if (movingRight)
        {
            targetPosition.x += speed * Time.deltaTime;
        }
        else
        {
            targetPosition.x -= speed * Time.deltaTime;
        }

        // Mueve el enemigo hacia la nueva posición
        transform.position = targetPosition;
        if (transform.position.x >= tilemapFlecha.size.x - 1) // Cambia según el tamaño de tu tilemap
        {
            movingRight = false; // Cambia la dirección a izquierda
            Quaternion rotacion = Quaternion.Euler(0f, 0f, 180f);
            root.transform.localRotation = rotacion;
        }
        else if (transform.position.x <= 0)
        {
            movingRight = true; // Cambia la dirección a derecha
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