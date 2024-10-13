using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecoleccionGemas : MonoBehaviour
{
    public CommerceSystem commerceSystem;
    public ContadorGlobal contadorGlobal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            commerceSystem.CollectGems(1);
            Destroy(gameObject);
            contadorGlobal.SumarGemas(1);
        }
    }
}