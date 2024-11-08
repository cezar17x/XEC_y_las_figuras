using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecoleccionEstrella : MonoBehaviour
{
    public EstrellasCollect estrellasCollect;
    public GameManager contadorGlobal;
    public GameObject Destello;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estrellasCollect.CollectStars(1);
            Destroy(gameObject);
            contadorGlobal.SumarEstrellas(1);
            Instantiate(Destello,transform.position, Quaternion.identity);
        }
    }
}
