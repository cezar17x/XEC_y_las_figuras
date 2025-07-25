using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomCircle : Enemy
{
    
    private List<Vector3> _emptyPoints = new();
    public Vector3 actualObjective;
    public float circleSpeed = 2f;
    public Tilemap tilemapRandom;
    
      public override void Start()
      {
        base.Start();
        EncontraPuntosVacios();
      }
    public  void EncontraPuntosVacios()
    {
        BoundsInt bounds = tilemapRandom.cellBounds;
        for (int x = bounds.xMin; x <= bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y <= bounds.yMax; y++)
            {
                if (tilemapRandom.GetTile(new Vector3Int(x, y, 0)) != null)
                {
                    _emptyPoints.Add(new Vector3(x + 0.5f, y + 0.5f, 0));
                    
                }
            }
        }
    }
    private  void FindRandomObject()
    {
        // si no hay objetivo actual, elegir uno aleatorio
        if (actualObjective == Vector3.zero)
        {
            actualObjective = _emptyPoints[Random.Range(0, _emptyPoints.Count)];
        }

        // mover al npc hacia el objetivo actual
        float distancia = Vector3.Distance(transform.position, actualObjective);
        if (distancia > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, actualObjective, circleSpeed * Time.deltaTime);
        }
        else
        {
            // si el npc llega al objetivo, elegir un nuevo objetivo aleatorio
            actualObjective = Vector3.zero;
        }
    }
    public override void Update()
    {
        base.Update();
        FindRandomObject();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Pared"))
        {
            actualObjective = Vector3.zero;
        }

    }
}