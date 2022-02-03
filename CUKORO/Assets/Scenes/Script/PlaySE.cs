using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour
{

    public AudioClip sound;

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}