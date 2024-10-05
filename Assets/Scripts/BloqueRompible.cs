using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BloqueRompible : MonoBehaviour
{
    public int hp;
    public Sprite[] fracturas;
    public SpriteRenderer sr;
    public UnityEvent onBloqueDestroy, onBloqueHit;



    public void Hit()
    {
        onBloqueHit.Invoke();
    }

    public void Damage()
    {
        hp--;
        if (hp == 0)
        {
            onBloqueDestroy.Invoke();
        }
        else
        {
            sr.sprite = fracturas[hp - 1];
            transform.localScale = new Vector3(0.359321922f, 0.364380419f, 0.381280005f);
        }

    }
}