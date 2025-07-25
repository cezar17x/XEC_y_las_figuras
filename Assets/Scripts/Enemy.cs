using UnityEngine;
using UnityEngine.Events;


public class Enemy : MonoBehaviour  
{
    public string nameEnemy;
    public int maxLife = 3;
    public int currentLife = 0;
    public GameObject particleEffect;
    public UnityEvent onDead;
    public virtual void Start()
    {
        currentLife = maxLife;
    }
    public virtual void TakeDamage(int damage)
    {
        currentLife -= damage;
        if (currentLife > 0)
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity);
        }
        else
        {
            onDead.Invoke();
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject, 2);
            Instantiate(particleEffect, collision.transform.position, Quaternion.identity);
        }
    }
    public virtual void Update() { }
}