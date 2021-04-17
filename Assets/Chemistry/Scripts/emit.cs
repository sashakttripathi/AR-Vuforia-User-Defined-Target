using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emit : MonoBehaviour
{
    

    public ParticleSystem particle1;
      public void OnPress()
    {
        
        ParticleSystem particle1 = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
         particle1.Play();

    }
    public void OnRelease()
    {
            ParticleSystem particle1 = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
        StartCoroutine(coroutineA());
        
    }

    IEnumerator coroutineA()
    {
        yield return new WaitForSeconds(2.3f);
        particle1.Stop();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnPress();
        }
        if(Input.GetMouseButtonUp(0))
        {
            OnRelease();
        }
    }

}