using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    public GameObject outFollow;
    public GameObject inFollow;
    public GameObject cylinderFollow;

    // For Change View Button
    public GameObject microScopeView;
    public GameObject normalCircut;

    //public GameObject slider;

    public Button changeViewButton;
    private bool isMicroScopeView = false;

    public Light bulbPointLight;

    public GameObject flashCube;
    public float flashTime = 1f;

    public float threshold = 2.0f;

    public Electrons[] electronsInScene = new Electrons[20];
    public GameObject[] neucleusInScene = new GameObject[20];

    public bool isThresholdCrossed = false;

    private Slider speedSlider;

    private void Start()
    {
        speedSlider = GetComponent<Slider>();
        electronsInScene = GameObject.FindObjectsOfType<Electrons>();

        speedSlider.onValueChanged.AddListener(ChangeRadiusAndSpeed);

        changeViewButton.onClick.AddListener(ChangeView);

        microScopeView.SetActive(false);
    }

    private void ChangeRadiusAndSpeed(float value)
    {
        CheckThreshold(value);

        ChangeMaterials(value);

        if (!isThresholdCrossed)
        {
            for (int i = 0; i < electronsInScene.Length; i++)
            {
                electronsInScene[i].ChangeRadius(value);
                electronsInScene[i].ChangeSpeed(value);
            }
        }
        else
        {
            for (int i = 0; i < electronsInScene.Length; i++)
            {
                electronsInScene[i].gameObject.SetActive(false);
            }
        }
    }

    private void CheckThreshold(float value)
    {
        if (value > threshold && !isThresholdCrossed)
        {
            //Debug.Log("Threshold Crossed and Flashing cube");

            isThresholdCrossed = true;
            cylinderFollow.gameObject.SetActive(true);

            for (int i = 0; i < neucleusInScene.Length; i++)
            {
                Material temp = neucleusInScene[i].GetComponent<MeshRenderer>().material;
                temp.EnableKeyword("_EMISSION");
            }

            bulbPointLight.enabled = true;
            //debugText.text = "Enabled";

            StartCoroutine(FlashCube());
        }
        else if (value < threshold && isThresholdCrossed)
        {
            //Debug.Log("Threshold down");

            for (int i = 0; i < neucleusInScene.Length; i++)
            {
                Material temp = neucleusInScene[i].GetComponent<MeshRenderer>().material;
                temp.DisableKeyword("_EMISSION");
            }

            for (int i = 0; i < electronsInScene.Length; i++)
            {
                electronsInScene[i].gameObject.SetActive(true);
            }

            bulbPointLight.enabled = false;

            cylinderFollow.gameObject.SetActive(false);
            isThresholdCrossed = false;
        }
    }

    private void ChangeMaterials(float value)
    {
        Material oM = outFollow.GetComponent<MeshRenderer>().material;
        Material iM = inFollow.GetComponent<MeshRenderer>().material;

        float alpha = 0;

        if (value <= 2f)
        {
            alpha = 1.5f;
        }
        else
        {
            alpha = value * 1.5f;
        }
        

        //Debug.Log(alpha);

        oM.SetFloat("_ColorMultiply", alpha);
        iM.SetFloat("_ColorMultiply", alpha);

        //oM.SetFloat("_ScrollSpeed", value * -0.2f);
        //iM.SetFloat("_ScrollSpeed", value * 0.2f);

        if (isThresholdCrossed)
        {
            Material cylinderM = cylinderFollow.GetComponent<MeshRenderer>().material;
            //cylinderM.SetFloat("_ScrollSpeed", value * -0.2f);
            if(value <= 2.5f)
            {
                cylinderM.SetFloat("_Alpha", value - 2f);
            }
            else
            {
                cylinderM.SetFloat("_Alpha", 0.7f);
            }
            //Debug.Log(value - 2f);
        }

        //outFollow.GetComponent<MeshRenderer>().material = oM;
        //inFollow.GetComponent<MeshRenderer>().material = iM;
    }

    private void ChangeView()
    {

        isMicroScopeView = !isMicroScopeView;

        if (isMicroScopeView)
        {
            microScopeView.SetActive(true);
            normalCircut.SetActive(false);
        }
        else
        {
            microScopeView.SetActive(false);
            normalCircut.SetActive(true);
        }
    }

    public IEnumerator FlashCube()
    {
        flashCube.gameObject.SetActive(true);

        Material fC = flashCube.GetComponent<MeshRenderer>().material;

        fC.EnableKeyword("_EMISSION");

        yield return new WaitForSeconds(flashTime);

        fC.DisableKeyword("_EMISSION");

        flashCube.gameObject.SetActive(false);
    }
}
