using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaEnemy : MonoBehaviour
{
    public int maxVida = 3;
    public int vidaActual = 0;
    public GameObject particleEffect;
    public UnityEvent onMuerte;
    private void Start()
    {
        vidaActual = maxVida;
    }
    public void TomaDaño(int daño)
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