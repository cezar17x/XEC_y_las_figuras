using UnityEngine;
using UnityEngine.Tilemaps;
public class Arrow : Enemy
{
    public Tilemap ArrowTilemap;
    public Vector3Int initialPosition;
    public float speed = 2f;
    public LayerMask layerPared;
    [HideInInspector]public bool movingRight = true;
    public Transform root;
    public override void Start()
    {
        base.Start();
        transform.position = ArrowTilemap.GetCellCenterWorld(initialPosition);
    }

    public override void Update()
    {
        base.Update();
        CalculeNewPosition();
        
    }
    public  void CalculeNewPosition()
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
        if (transform.position.x >= ArrowTilemap.size.x - 1) // Cambia seg�n el tama�o de tu tilemap
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
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}