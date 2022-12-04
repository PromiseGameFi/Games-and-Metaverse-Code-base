using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//KeyName is the name of the key in Input Manager

public class SetActiveFalse : MonoBehaviour
{
    public GameObject[] thelight;
    public bool isFly;
    
    void Start()
    {
        isFly = false;
        foreach (GameObject item in thelight)
            {
               item.SetActive(false);
            }
    }
    // Update is called once per frame
    void Update()
    {
        
            
            if(Input.GetButtonDown("KeyName"))
            {
            
                if(isFly== false)
                {
                    foreach (GameObject item in thelight)
                    {
                       item.SetActive(true);
                       isFly = true;
                    
                    }
                }
                else
                {
                    foreach (GameObject item in thelight)
                    {
                       item.SetActive(false);
                       isFly = false;

                    }
                }
            }
        
    }
}