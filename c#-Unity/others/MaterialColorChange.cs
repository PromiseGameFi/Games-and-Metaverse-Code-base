using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Beginner friendly material changing Script
//You will need to create an input manager i have called mine Fly so that you can use in line 28
//Supports two mterials for now 

public class MaterialColorChange : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    public bool matActive;
    // Start is called before the first frame update
    void Start()
    {
        x=0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
        matActive = false;
    }

    public void Update()
    {
        rend.sharedMaterial = material[x];

        if(Input.GetButtonDown("Fly"))
        {
            if(x<2)
            {
                x++;
                if(matActive == false)
                {
                    matActive = true;
                }
            }
            
            if(x>=2)
            {
                x=0;
                if(matActive == true)
                {
                    matActive = false;
                }
            }
        }
      
       
        
    }

}
