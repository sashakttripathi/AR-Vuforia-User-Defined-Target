using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableforce : MonoBehaviour
{
    public ConstantForce force;
    public int frame;
    IEnumerator DisableForce()
    {
        yield return new WaitUntil(()=> frame >5);
        force.enabled = !force.enabled;
    }
    // Start is called before the first frame update
    void Start()
    {
        force = GetComponent<ConstantForce>();
        StartCoroutine(DisableForce());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (frame <= 5)
                frame++;
        }
    }
}
