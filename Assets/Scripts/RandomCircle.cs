using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCircle : Enemy
{
    private List<Vector3> puntosvacios = new();
    public string _name;
    public RandomCircle(string name): base(name)
    {
        _name = name;
    }
      public override void Start()
      {
        base.Start();
      }
    public override void EncontraPuntosVacios()
    {
        BoundsInt bounds = tilemapRandom.cellBounds;
        for (int x = bounds.xMin; x <= bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y <= bounds.yMax; y++)
            {
                if (tilemapRandom.GetTile(new Vector3Int(x, y, 0)) != null)
                {
                    puntosvacios.Add(new Vector3(x + 0.5f, y + 0.5f, 0));
                }
            }
        }
    }
    public override void EncontrarObjetivoRandom()
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
    public override void Update()
    {
        base.Update();
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