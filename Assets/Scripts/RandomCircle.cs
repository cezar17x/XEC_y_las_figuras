using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomCircle : MonoBehaviour
{
    public float velocidad = 2f;
    public LayerMask capa;
    private List<Vector3> puntosvacios = new List<Vector3>();
    public Vector3 objetivoactual;
    public Tilemap tilemap;

    void Start()
    {
        BoundsInt bounds = tilemap.cellBounds;
        for (int x = bounds.xMin; x <= bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y <= bounds.yMax; y++)
            {
                if (tilemap.GetTile(new Vector3Int(x, y, 0)) != null)
                {
                    puntosvacios.Add(new Vector3(x + 0.5f, y + 0.5f, 0));
                }
            }
        }
    }

    void Update()
    {
        // si no hay objetivo actual, elegir uno aleatorio
        if (objetivoactual == Vector3.zero)
        {
            objetivoactual = puntosvacios[Random.Range(0, puntosvacios.Count)];
        }

        // mover al npc hacia el objetivo actual
        float distancia = Vector3.Distance(transform.position, objetivoactual);
        if (distancia > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivoactual, velocidad * Time.deltaTime);
        }
        else
        {
            // si el npc llega al objetivo, elegir un nuevo objetivo aleatorio
            objetivoactual = Vector3.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // si el npc choca con algo en la capa de colision, elegir un nuevo objetivo aleatorio
        if (capa == collision.gameObject.layer)
        {
            objetivoactual = Vector3.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (capa == collision.gameObject.layer)
        {
            objetivoactual = Vector3.zero;
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaPlayer>().Matar();
        }
    }
}