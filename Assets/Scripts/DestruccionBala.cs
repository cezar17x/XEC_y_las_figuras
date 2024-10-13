using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionBala : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("rompible"))
        {
            BloqueRompible br = collision.transform.GetComponent<BloqueRompible>();
            br.Hit();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            VidaEnemy vida = collision.gameObject.GetComponent<VidaEnemy>();
            vida.TomaDaño(1);
        }
    }
}