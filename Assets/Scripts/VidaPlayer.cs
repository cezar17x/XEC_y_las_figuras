using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaPlayer : MonoBehaviour
{
    public GameObject particleEffect;
    public UnityEvent onMuerte;
    public void Matar()
    {
        onMuerte.Invoke();
        Instantiate(particleEffect, transform.position,Quaternion.identity);
    }
}