using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSE : MonoBehaviour
{

    public AudioClip sound;

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}