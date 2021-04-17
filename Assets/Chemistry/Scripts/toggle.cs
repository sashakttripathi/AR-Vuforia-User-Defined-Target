using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour
{

    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;

    emit e1, e2;
    emitlongest e3;
    

    private void Start()
    {
        e3 = particle3.GetComponent<emitlongest>();
        e1 = particle1.GetComponent<emit>();
        e2 = particle2.GetComponent<emit>();
    }

    void LateUpdate()
    {
        //e.OnPress();

        if (Input.GetMouseButtonDown(0)&& PlayerPrefs.GetInt("emitting")==20)
        {

        }
        if (Input.GetMouseButtonUp(0))
        {
            e3.OnRelease();
            e1.OnRelease();
            e2.OnRelease();
        }
    }
}
