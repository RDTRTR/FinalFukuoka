using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            GameObject[] planes = GameObject.FindGameObjectsWithTag("Switch1");

            var change = this.gameObject.GetComponent<Renderer>().material;

            for (int i = 0; i < planes.Length; i++)
            {
                planes[i].gameObject.GetComponent<Renderer>().material = change;
            }
        }
    }

}
