using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour  //superclase que hereda
{
    [Header("General")]
    public string nameEnemy;
    public int maxVida = 3;
    public int vidaActual = 0;
    public GameObject particleEffect;
    public UnityEvent onMuerte;
    [Header("Flecha")]
    public Tilemap tilemapFlecha;
    public Vector3Int posicionInicial;
    public float speed = 2f;
    public LayerMask layerPared;
    [HideInInspector]public bool movingRight = true;
    public Transform root;
    [Header("Random Circle")]
    public Vector3 objetivoactual;
    public float velocidad = 2f;
    public Tilemap tilemapRandom;
    [Header("Hexagono")]
    public Rigidbody2D rb;
    public GameObject objeto;
    public float alturaInicial = 10f;
    public float tiempoAdvertencia = 2f;
    public CanvasGroup advertenciaCanvas;
    //public Enemy[] enemigos;
 
    public Enemy(string name)
    {
        this.nameEnemy = name;
    }
    public virtual void Start()
    {
        vidaActual = maxVida;
        transform.position = tilemapFlecha.GetCellCenterWorld(posicionInicial);
       EncontraPuntosVacios();
        Caer();
    }
    public virtual void TomaDaño(int daño)
    {
        //print("daño");
    }
    public virtual void EncontraPuntosVacios()//polimorfismo
    {
        //print("randoms");
    }
    public virtual void Caer()
    {
        //print("cayo");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Pared"))
        {
                objetivoactual = Vector3.zero;
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
            Instantiate(particleEffect, collision.transform.position, Quaternion.identity);
        }
    }
    public virtual void Update()
    {
       CalcularNuevaPosicion();
       EncontrarObjetivoRandom();
    }
    public virtual void CalcularNuevaPosicion()
    {
        //print("calculo");
    }
    public virtual void EncontrarObjetivoRandom()
    {
        //print("puntosrandom");
    }
}