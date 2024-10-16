using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Flecha : MonoBehaviour
{
    public Tilemap tilemap;  // Tilemap que recorre el enemigo
    public float speed = 2f; // Velocidad de movimiento
    public Transform root;
    private bool movingRight = true;
    public Vector3Int posicionInicial;
    public LayerMask layerPared;

    void Start()
    {
        transform.position = tilemap.GetCellCenterWorld(posicionInicial);
    }

    void Update()
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
        if (transform.position.x >= tilemap.size.x - 1) // Cambia según el tamaño de tu tilemap
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
            collision.gameObject.GetComponent<VidaPlayer>().Matar();
            Destroy(collision.gameObject, 2);
        }
    }
}