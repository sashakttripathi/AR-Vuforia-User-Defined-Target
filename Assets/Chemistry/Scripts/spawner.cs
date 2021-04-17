using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private Transform spawnPos;
    public GameObject spawnee;



    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spawnPos = Camera.main.transform;
           Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
     
        }
        
    }
  
}
