﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio2 : MonoBehaviour
{
  

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("start", 20);
        
       
    }
}
