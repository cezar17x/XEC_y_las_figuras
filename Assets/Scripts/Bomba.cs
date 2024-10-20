using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomba : MonoBehaviour
{
    // Configuración de los raycasts
    public float distanciaRayo = 1f;
    public Vector3 offset;
    public int maxDistance = 1;
    public LayerMask capaTilemap;
    public Tilemap tilemap;
    private void Start()
    {
        DestruirTilemapsEnRango();
        StartCoroutine(Explotar());
        StopCoroutine(Explotar());
    }
    public void DestruirTilemapsEnRango()
    {
        for (int i = 0; i < maxDistance; i++) { 
            // Puntos de origen para los raycasts
            Vector2 puntoArriba = transform.position + new Vector3(0, distanciaRayo * (i), 0) + offset;
            Vector2 puntoAbajo = transform.position + new Vector3(0, -distanciaRayo * (i), 0) + offset;
            Vector2 puntoIzquierda = transform.position + new Vector3(distanciaRayo * (i), 0, 0) + offset;
            Vector2 puntoDerecha = transform.position + new Vector3(-distanciaRayo * (i), 0, 0) + offset;

            // Raycasts en forma de signo más
            RaycastHit2D hitArriba = Physics2D.Raycast(puntoArriba, Vector2.down, distanciaRayo, capaTilemap);
            RaycastHit2D hitAbajo = Physics2D.Raycast(puntoAbajo, Vector2.up, distanciaRayo, capaTilemap);
            RaycastHit2D hitIzquierda = Physics2D.Raycast(puntoIzquierda, Vector2.right, distanciaRayo, capaTilemap);
            RaycastHit2D hitDerecha = Physics2D.Raycast(puntoDerecha, Vector2.left, distanciaRayo, capaTilemap);
            if (hitArriba.collider != null || hitAbajo.collider != null || hitIzquierda.collider != null || hitDerecha.collider != null)
            {
                tilemap.SetTile(Vector3Int.RoundToInt(puntoArriba), null);
                tilemap.SetTile(Vector3Int.RoundToInt(puntoAbajo), null);
                tilemap.SetTile(Vector3Int.RoundToInt(puntoIzquierda), null);
                tilemap.SetTile(Vector3Int.RoundToInt(puntoDerecha), null);
            }
        }
    }
    IEnumerator Explotar()
    {
        yield return new WaitForSeconds(3f);
        DestruirTilemapsEnRango();
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Vector2 puntoArriba = transform.position + new Vector3(0, distanciaRayo, 0) + offset;
        Vector2 puntoAbajo = transform.position + new Vector3(0, -distanciaRayo, 0) + offset;
        Vector2 puntoIzquierda = transform.position + new Vector3(distanciaRayo, 0, 0) + offset;
        Vector2 puntoDerecha = transform.position + new Vector3(-distanciaRayo, 0, 0) + offset;
        Gizmos.DrawLine(Vector3Int.RoundToInt(puntoArriba), Vector2.up);
        Gizmos.DrawLine(Vector3Int.RoundToInt(puntoAbajo), Vector2.down);
        Gizmos.DrawLine(Vector3Int.RoundToInt(puntoIzquierda), Vector2.left);
        Gizmos.DrawLine(Vector3Int.RoundToInt(puntoDerecha), Vector2.right);
    }
}