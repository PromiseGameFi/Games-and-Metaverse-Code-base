using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Changing gameobject at runtime
public class ChangeGameObject : MonoBehaviour
{
    public GameObject HeroOne;
    public GameObject HeroTwo;
    public GameObject spawnPoint;
    public bool isChange;

    void Start()
    {
        isChange = true;
        Destroy(HeroTwo);
        Instantiate(HeroOne, spawnPoint.transform.position, spawnPoint.transform.rotation );
    }
    void Update()
    {
        if(Input.GetButtonDown("Onthe"))
        {
            if(isChange == true)
            {
                isChange = false;
                Instantiate(HeroTwo, GameObject.FindWithTag("Player").transform.position, GameObject.FindWithTag("Player").transform.rotation );
                Destroy(GameObject.FindWithTag("Player"));
                
                
            }
            else
            {
                isChange = true;
                Instantiate(HeroOne, GameObject.FindWithTag("Playertwo").transform.position, GameObject.FindWithTag("Playertwo").transform.rotation );
                Destroy(GameObject.FindWithTag("Playertwo"));
              
            }
        }
    }

}