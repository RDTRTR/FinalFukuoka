using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistance : MonoBehaviour
{
    public GameObject cubeA;
    public GameObject cubeB;

    void Start()
    {
        Vector3 posA = cubeA.transform.position;
        Vector3 posB = cubeB.transform.position;
        float dis = Vector3.Distance(posA, posB);
        Debug.Log("‹——£ : " + dis);
    }
}