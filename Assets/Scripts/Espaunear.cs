using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espaunear : MonoBehaviour
{
    public GameObject prefab;
    public Transform target;
    private void Start()
    {
        if (target == null)
            target = gameObject.transform;
    }
    public void Spawn()
    {
        Vector3 pos = target.position;
        Instantiate(prefab, pos, Quaternion.identity);
    }
}