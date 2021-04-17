using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowatom : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "emittedparticle")
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
