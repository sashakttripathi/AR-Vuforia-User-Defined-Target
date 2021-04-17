using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch1 : MonoBehaviour
{
    public AudioSource a1;
    public AudioSource a2;
    void Start()
    {
       
        PlayerPrefs.SetInt("start", 0);
    }

    void Update()
    {
     if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "pencil")
                {

                    PlayerPrefs.SetInt("start", 10);
                    a1.Stop();
                    a2.Play();
                }
                if (hit.transform.name == "sketchpen")
                {

                    PlayerPrefs.SetInt("start", 20);
                    a2.Stop();
                    
                }
            }
        }
    }
   /* private void OnMouseDown()
    {
        PlayerPrefs.SetInt("start", 10);
        a1.Stop();
        a2.Play();
        
    }*/


}