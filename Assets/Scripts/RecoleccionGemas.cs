using UnityEngine;

public class RecoleccionGemas : MonoBehaviour
{
    public GameManager GM;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GM.CollectGems(1);
            Destroy(gameObject);
            GM.SumarGemas(1);
        }
    }
}