using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
   

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "destroyer")
            Destruction();
       

    }

    void Destruction()
    {
        Destroy(this.gameObject);
    }

}
