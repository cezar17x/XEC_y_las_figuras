using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecoleccionEstrella : MonoBehaviour
{
    public EstrellasCollect estrellasCollect;
    public ContadorGlobal contadorGlobal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estrellasCollect.CollectStars(1);
            Destroy(gameObject);
            contadorGlobal.SumarEstrellas(1);
        }
    }
}
