using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class MovimientoConSlide : MonoBehaviour
{
    public bool puedeMoverse;
    public float velocidadMovimiento;
    public LayerMask layerMask;
    public Animator anim;
    public GameObject hitEffectPrefab;
    public UnityEvent onWallHit, onChocoConTrampa, onChocoEsquina;
    public Transform cuerpo;
    public SpriteRenderer SPCuerpo;
    public Sprite normalSprite;


    bool moviendose;
    bool pegadoAPared;
    Vector3 siguienteDireccion;
    Vector3 velocidad;
    public Vector3 normalScale;

    private void Start()
    {
        siguienteDireccion = transform.position;  // cuando inicia el juego el player se mueve hacia la misma posicion donde esta
    }

    public void MoverIzquierda() => Mover(Vector3.left);
    public void MoverDerecha() => Mover(Vector3.right);
    public void MoverArriba() => Mover(Vector3.up);
    public void MoverAbajo() => Mover(Vector3.down);


    public void Mover(Vector3 direccion)
    {
        if (moviendose) return;


        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, direccion, 100, layerMask);
        // mientras el raycast choque contra cualquier collider del layerMask el player se mover� hacia esa direccion
        if (hit2d.collider != null)
        {

            siguienteDireccion = hit2d.point + (Vector2)(direccion * 0.5f) * -1; // <== esto es para que no se superponga con la pared suponiendo que la caja mide 1 x 1
            moviendose = true;
            velocidad = direccion;

            pegadoAPared = Vector3.Distance(transform.position, siguienteDireccion) < 0.1f;

            /* esto es para decidir cual animaci�n de movimiento reproducir
            string animMover = "";
            if (direccion.y == 1)
                animMover = "MoveUp";
            if (direccion.y == -1)
                animMover = "MoveDown";
            if (direccion.x == 1)
                animMover = "MoveRight";
            if (direccion.x == -1)
                animMover = "MoveLeft";

            anim.Play(animMover);*/

        }
    }


    private void FixedUpdate()
    {
        if (!puedeMoverse) return;

        Movimiento();

    }


    void Movimiento()
    {
        if (moviendose)
        {
            // el player se mueve hacia la posicion donde choco el raycast usando MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, siguienteDireccion, velocidadMovimiento * Time.fixedDeltaTime);

            if (transform.position == siguienteDireccion)
            {
                moviendose = false;
                AlcanzoObjetivo();
            }
        }

    }

    void AlcanzoObjetivo()
    {
        onWallHit.Invoke();

        // chequear si choco con un bloque rompible
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, velocidad, 100, layerMask);

        if (hit2D.collider.CompareTag("rompible"))
        {
            BloqueRompible br = hit2D.transform.GetComponent<BloqueRompible>();

            if (br.hp == 1)
            {
                // si el bloque tiene 1 hp significa que el golpe lo va a destruir, entonces el player debe seguir con su trayectoria
                // buscar el siguiente punto de contacto desde la posicion del bloque rompible hacia la direccion de movimiento 
                RaycastHit2D wall = Physics2D.Raycast(hit2D.transform.position, velocidad, 100, layerMask);
                if (wall.collider != null)
                {
                    siguienteDireccion = wall.point + (Vector2)(velocidad * 0.5f) * -1;
                    moviendose = true;
                }
                br.Hit();

                return;  // me salgo de la funcion porque aun no debe aterrizar el player
            }
            else
            {
                br.Hit();
            }

        }
        else if (hit2D.collider.CompareTag("trampa"))
            ChocoConTrampa();

        //AnimacionAterrizaje();
        EfectoParticulaImpacto();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EsquinaID"))
        {
            onChocoEsquina.Invoke();
            SPCuerpo.flipX = true;
            cuerpo.transform.localScale = new Vector3(0.204500005f, 0.204500005f, 0.204500005f);
        }
        else if (collision.gameObject.CompareTag("EsquinaII"))
        {
            onChocoEsquina.Invoke();
            SPCuerpo.flipX = false;
            cuerpo.transform.localScale = new Vector3(0.204500005f, 0.204500005f, 0.204500005f);
        }
        else if (collision.gameObject.CompareTag("EsquinaSD"))
        {
            onChocoEsquina.Invoke();
            SPCuerpo.flipX = false;
            cuerpo.transform.localScale = new Vector3(0.204500005f, 0.204500005f, 0.204500005f);
            Quaternion rotacion = Quaternion.Euler(0f, 0f, 180f);
            cuerpo.transform.localRotation *= rotacion;
        }
        else if (collision.gameObject.CompareTag("EsquinaSI"))
        {
            onChocoEsquina.Invoke();
            SPCuerpo.flipX = true;
            cuerpo.transform.localScale = new Vector3(0.204500005f, 0.204500005f, 0.204500005f);
            Quaternion rotacion = Quaternion.Euler(0f, 0f, 180f);
            cuerpo.transform.localRotation *= rotacion;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EsquinaID"))
        {
            SPCuerpo.flipX = false;
            cuerpo.transform.localScale = normalScale;
            SPCuerpo.sprite = normalSprite;
        }
        else if (collision.gameObject.CompareTag("EsquinaII"))
        {
            SPCuerpo.flipX = false;
            cuerpo.transform.localScale = normalScale;
            SPCuerpo.sprite = normalSprite;
        }
        else if (collision.gameObject.CompareTag("EsquinaSD"))
        {
            SPCuerpo.flipX = false;
            cuerpo.transform.localScale = normalScale;
            cuerpo.transform.localRotation = Quaternion.Euler(0, 0, 0);
            SPCuerpo.sprite = normalSprite;
        }
        else if (collision.gameObject.CompareTag("EsquinaSI"))
        {
            SPCuerpo.flipX = false;
            cuerpo.transform.localScale = normalScale;
            Quaternion rotacion = Quaternion.Euler(0f, 0f, 0f);
            cuerpo.transform.localRotation = rotacion;
            SPCuerpo.sprite = normalSprite;
        }
    }
    void AnimacionAterrizaje()
    {
        // esto es para decidir cual animaci�n de aterrizaje reproducir
        string landAnim = "";

        if (velocidad.y == 1)
            landAnim = "LandUp";
        if (velocidad.y == -1)
            landAnim = "LandDown";
        if (velocidad.x == 1)
            landAnim = "LandRight";
        if (velocidad.x == -1)
            landAnim = "LandLeft";

        anim.Play(landAnim);
    }

    void EfectoParticulaImpacto()
    {
        if (pegadoAPared) return;

        //Efecto particula de impacto solo si llega viajando y no si ya est� pegado a la pared
        Vector3 posEffect = transform.position;
        posEffect.z = -0.1f;
        GameObject hitEffect = Instantiate(hitEffectPrefab, posEffect, Quaternion.identity);
        hitEffect.transform.up = velocidad * -1;

    }

    public void ChocoConTrampa()
    {
        onChocoConTrampa.Invoke();
    }

}