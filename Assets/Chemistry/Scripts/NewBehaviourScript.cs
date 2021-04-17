using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pencil;
    public GameObject line;
    public GameObject sketchpen;
    public GameObject dot;
    public GameObject clip;
    public GameObject filterpaper;
    public GameObject wetpaper;
    public GameObject colourmove;
    public GameObject reddot;
    public GameObject bluedot;
    public GameObject glasslid;
    public GameObject paper;
    public GameObject dots;
    public GameObject arrow1;
    public GameObject arrow2;

    public AudioSource a3;
    public AudioSource a2;
    public AudioSource a4;
    public AudioSource a5;
    bool luv = false;
    bool luv2 = false;
    bool luv4 = false;
    bool luv5 = false;
    bool luv7 = false;
    bool luv8 = false;
    bool luv9 = false;
    bool luv10 = false;
    bool luv11 = false;
    bool luv12 = false;
    bool luv13 = false;
    bool luv14 = false;
    bool luv15 = false;
    bool luv16 = true;
    bool luv17 = false;
    bool luv18 = true;
    bool luv19 = false;
    bool luv20 = false;
    void StartSimulation()
    {
       
        luv = false;
        luv2 = false;
        luv4 = false;
        luv5 = false;
        luv7 = false;
        luv8 = false;
        luv9 = false;
        luv10 = false;
        luv11 = false;
        luv12 = false;
        luv13 = false;
        luv14 = false;
        luv15 = false;
        luv16 = true;
        luv17 = false;
        luv18 = true;
        luv19 = false;
        luv20 = false;
     
        pencil.transform.localPosition = new Vector3(3.98f, 4.14f, -4f);
        sketchpen.transform.localPosition = new Vector3(3.98f, 4.14f, -0.71f);
        clip.transform.localPosition = new Vector3(0f, 1.4f, 2.7f);
        glasslid.transform.localPosition = new Vector3(4.08f, 7f, 9.8f);      
        line.transform.localScale = new Vector3(0f, 0f, 0.01f);
        wetpaper.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        colourmove.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
        dots.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        arrow1.gameObject.SetActive(true);
        paper.transform.localPosition = new Vector3(-0.16f, -2.39f, -0.07f);
        CancelInvoke();
        paper.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        filterpaper.transform.localPosition = new Vector3(4.12f, 8f, 1.27f);
    }
    void Start()
    { dot.gameObject.SetActive(false);
      colourmove.gameObject.SetActive(false);
      reddot.gameObject.SetActive(false);
      bluedot.gameObject.SetActive(false);
      arrow2.gameObject.SetActive(false);
    

        // lr1.alignment = LineAlignment.View;
    }

    /* void OnMouseDown()
     {
         StartSimulation();
     }*/ 



    void Update()
    {
        
        arrow1move();
        if (luv19 == true)
        {
            arrow1.gameObject.SetActive(false);

        }
        if (luv20 == true)
        {
            arrow2.gameObject.SetActive(false);
            
            Debug.Log("7");
        }
        if (PlayerPrefs.GetInt("start") == 10)
        {
          
            penciltouch();
            
        }
        if (PlayerPrefs.GetInt("start") == 20)
        {
            sketchpentouch();
           
           
        }
        if (luv7 == true && luv12 == false)
        {
            clipattatch();
        }
        if (luv8 == true && luv9 == false)
        {
            filterpaper1();
            a3.Play();
        }
        if (luv9 == true && luv11 == false)
        {
            filterpaper2();
            a4.Play();
        }
        if (luv10 == true && luv11 == false && luv13 == false)
        {
            wetup();
            
        }
        if (luv11 == true)
        {
            Vector3 temp14 = new Vector3(4.08f, 7f, 9.8f);
            glasslid.transform.localPosition = Vector3.MoveTowards(glasslid.transform.localPosition, temp14, 0.05f);
            Invoke("filterpaper3", 3);
           

        }
        if (luv12 == true && luv14 == false)
        {
            paperclipback();
            a5.Play();

        }
        if (luv13 == true)
        {
            drypaper();
          

        }
        if (luv14 == true)
        {
            Vector3 temp15 = new Vector3(0f, 0f, 270f);
            paper.transform.localEulerAngles = Vector3.Lerp(paper.transform.localEulerAngles, temp15, 0.05f);
          
        }
    }

    void arrow2move()
    {
        
        arrow2.gameObject.SetActive(true);
        if (luv18 == true)
        {
            Vector3 temp19 = new Vector3(3.98f, 7.2f, -3.75f);
            arrow2.transform.localPosition = Vector3.MoveTowards(arrow2.transform.localPosition, temp19, 0.05f);
            if (arrow2.transform.localPosition == temp19)
            {
                luv17 = true;
                luv18 = false;
            }
        }
        if (luv17 == true)
        {
            Vector3 temp20 = new Vector3(3.98f, 6.9f, -4.2f);
            arrow2.transform.localPosition = Vector3.MoveTowards(arrow2.transform.localPosition, temp20, 0.05f);
            if (arrow2.transform.localPosition == temp20)
            {
                luv18 = true;
                luv17 = false;
            }
        }
    }

    private void arrow1move()
    {
        if (luv16 == true)
        {
            Vector3 temp19 = new Vector3(3.98f, 5.5f, -6.2f);
            arrow1.transform.localPosition = Vector3.MoveTowards(arrow1.transform.localPosition, temp19, 0.05f);
            if (arrow1.transform.localPosition == temp19)
            {
                luv15 = true;
                luv16 = false;
            }
        }
        if (luv15 == true)
        {
            Vector3 temp20 = new Vector3(3.98f, 5.1f, -6.74f);
            arrow1.transform.localPosition = Vector3.MoveTowards(arrow1.transform.localPosition, temp20, 0.05f);
            if (arrow1.transform.localPosition == temp20)
            {
                luv16 = true;
                luv15 = false;
            }
        }
    }

    void drypaper()
    {
        Vector3 temp17 = wetpaper.transform.localScale;

        if (temp17.y >= 0)
        {
            temp17.y -= 0.004f;
        }
        else if (temp17.x >= 0 && temp17.z >= 0)
        {
            temp17.x -= Time.deltaTime * 2;
            temp17.z -= Time.deltaTime * 2;
        }
        wetpaper.transform.localScale = temp17;

        reddot.gameObject.SetActive(true);
        bluedot.gameObject.SetActive(true);
        Invoke("dotappearing", 2);
    }

    private void dotappearing()
    {
        Vector3 temp18 = new Vector3(1f, 1f, 1f);
        dots.transform.localScale = Vector3.Lerp(dots.transform.localScale, temp18, 0.03f);
        if (dots.transform.localScale == temp18)
        {
            luv14 = true;
        }
    }

    private void paperclipback()
    {
        

        Vector3 temp16 = new Vector3(-0.037f, -7.18f, -4.61f);
        paper.transform.localPosition = Vector3.MoveTowards(paper.transform.localPosition, temp16, 0.05f);
        if (paper.transform.localPosition == temp16)
        {
            luv13 = true;
        }
    }

    void filterpaper3()
    {
        Vector3 temp12 = new Vector3(4.12f, 13f, 6.8f);
        filterpaper.transform.localPosition = Vector3.MoveTowards(filterpaper.transform.localPosition, temp12, 0.05f);
        if (filterpaper.transform.localPosition == temp12)
        {
            luv12 = true;
            
        }
    }

    void wetup()
    {
        
        Vector3 temp10 = wetpaper.transform.localScale;
        if (temp10.x <= 1 && temp10.z <= 1)
        {
            temp10.x += Time.deltaTime * 2;
            temp10.z += Time.deltaTime * 2;
        }
        else if (temp10.y <= 1)
        {
            temp10.y += 0.004f;
        }
        wetpaper.transform.localScale = temp10;
        Invoke("strtafter", 1); 

    }

    void strtafter()
    {
       
        Vector3 temp11 = colourmove.transform.localScale;
        if (temp11.x <= 1 && temp11.z <= 1)
        {
            temp11.x += Time.deltaTime * 2;
            temp11.z += Time.deltaTime * 2;
        }
        else if (temp11.y <= 1)
        {
            temp11.y += 0.005f;
        }
        else { luv11 = true; }
        colourmove.transform.localScale = temp11;
    }

    void filterpaper2()
    {
        Vector3 temp9 = new Vector3(4.12f, 5f, 6.8f);
        filterpaper.transform.localPosition = Vector3.MoveTowards(filterpaper.transform.localPosition, temp9, 0.05f);
        if (filterpaper.transform.localPosition == temp9)
        {
            luv10 = true;
            colourmove.gameObject.SetActive(true);
        }

        Invoke("glassliddown", 2);

    }

   void glassliddown()
    {
        Vector3 temp13 = new Vector3(4.08f, 6.23f, 6.8f);
        glasslid.transform.localPosition = Vector3.MoveTowards(glasslid.transform.localPosition, temp13, 0.05f);
    }

    void filterpaper1()
    {
        Vector3 temp8 = new Vector3(4.12f, 13f, 6.8f);
        filterpaper.transform.localPosition = Vector3.MoveTowards(filterpaper.transform.localPosition, temp8, 0.05f);
        if (filterpaper.transform.localPosition == temp8)
        {
            luv9 = true;
        }
       

    }

    void clipattatch()
    {
        Vector3 temp7 = new Vector3(0f, 0.34f, 0.0157f);
        clip.transform.localPosition = Vector3.MoveTowards(clip.transform.localPosition, temp7, 0.05f);
        if (clip.transform.localPosition == temp7)
        {
            luv8 = true;
        }
    }

    void sketchpentouch()
    {
        if (luv4 == true && luv5 == false)
        {
            sketchpen1();
            luv20 = true;
        }
        if (luv5 == true)
        {
            sketchpen2();
        }
    }

    void sketchpen2()
    {
        Vector3 temp6 = new Vector3(3.98f, 4.14f, -0.71f);
        sketchpen.transform.localPosition = Vector3.MoveTowards(sketchpen.transform.localPosition, temp6, 0.05f);
        if(sketchpen.transform.localPosition == temp6)
        {
            luv7 = true;
        }
    }

    void sketchpen1()
        {
            Vector3 temp5 = new Vector3(3.98f, 4.14f, 1.25f);
            sketchpen.transform.localPosition = Vector3.MoveTowards(sketchpen.transform.localPosition, temp5, 0.05f);
            if (sketchpen.transform.localPosition == temp5)
            {
                dot.gameObject.SetActive(true);
                luv5 = true;
            }
        }

        void penciltouch()
        {
            if (luv == false)
            {
                pencil1();
               luv19 = true;
            }

            if (luv == true)
            {
                sketching();

                if (luv2 == false)
                {
                    pencil2();
                }
            }

            if (luv2 == true)
            {
                pencil3();
           
            }
        }

        void pencil3()
        {
            Vector3 temp4 = new Vector3(3.98f, 4.14f, -4f);
            pencil.transform.localPosition = Vector3.MoveTowards(pencil.transform.localPosition, temp4, 0.05f);
            if (pencil.transform.localPosition == temp4)
            {
            
            luv4 = true;
            if (luv20 == false) {
                arrow2move();
                
            }          
            }
        
        }

        void pencil2()
        {
            Vector3 temp3 = new Vector3(3.98f, 4.14f, 2.05f);
            pencil.transform.localPosition = Vector3.MoveTowards(pencil.transform.localPosition, temp3, 0.05f);
            if (pencil.transform.localPosition == temp3)
            { luv2 = true; }
        }

        void pencil1()
        {
            Vector3 temp2 = new Vector3(3.98f, 4.14f, 0.45f);
            pencil.transform.localPosition = Vector3.MoveTowards(pencil.transform.localPosition, temp2, 0.05f);
            if (pencil.transform.localPosition == temp2)
            { luv = true; }
        }


        void sketching()
        {
            Vector3 temp = new Vector3(1f, 1f, 1f);
            line.transform.localScale = Vector3.Lerp(line.transform.localScale, temp, 0.05f);
        }

    }




