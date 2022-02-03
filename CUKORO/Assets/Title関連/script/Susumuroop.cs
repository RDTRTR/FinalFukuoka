using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Susumuroop : MonoBehaviour
{
    private Vector3 Susumupos;

    void Start()
    {
        Susumupos = transform.position;
    }

 
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 55.0f + Susumupos.x, Susumupos.y, Susumupos.z);
    }
}
