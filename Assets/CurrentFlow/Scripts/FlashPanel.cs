using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class FlashPanel : MonoBehaviour
{
    public Image panelImage;
    public float speedtime = 0.5f;

    private float elapsedTime = 0f;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FlashImage());
        }
    }

    public IEnumerator FlashImage()
    {
        Color tempColor = panelImage.color;

        while(elapsedTime < speedtime)
        {
            tempColor.a = Mathf.Lerp(0f, 255f, elapsedTime / speedtime);
            panelImage.color = tempColor;

            elapsedTime += Time.deltaTime;

            Debug.Log("Increasing");

            yield return null;
        }

        elapsedTime = 0f;
        tempColor = panelImage.color;

        while (elapsedTime < speedtime)
        {
            tempColor.a = Mathf.Lerp(255f, 0f, elapsedTime / speedtime);
            Debug.Log(tempColor.a);
            panelImage.color = tempColor;

            elapsedTime += Time.deltaTime;
            
            Debug.Log("Decreasing");

            yield return null;
        }
        elapsedTime = 0f;

        tempColor.a = 0f;
        panelImage.color = tempColor;

        yield return null;
    }
}
