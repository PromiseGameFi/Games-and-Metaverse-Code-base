using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public GameObject EffectVisual;
    public bool IsChange;
    // Start is called before the first frame update
    void Start()
    {
        PlayerOne.SetActive(true);
        PlayerTwo.SetActive(false);
        EffectVisual.SetActive(false);
        IsChange= true;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.B) && IsChange)
        {
            StartCoroutine(StartVfx());
            PlayerOne.GetComponent<Animator>().Play("Change");
            IsChange= false;
            Invoke("SetPlayerTwo", 1f);
            
        }
        else if(Input.GetKeyDown(KeyCode.B) && !IsChange)
        {
            StartCoroutine(StartVfx());
            PlayerTwo.GetComponent<Animator>().Play("Change");
            IsChange = true;
            Invoke("SetPlayerOne", 1f);
            
        }
      
        
    }

    public void SetPlayerTwo()
    {
        PlayerTwo.transform.position = PlayerOne.transform.position;
        PlayerTwo.transform.rotation = PlayerOne.transform.rotation;
        PlayerOne.SetActive(false);
        PlayerTwo.SetActive(true);
        PlayerTwo.GetComponent<Animator>().Play("Changer");
        IsChange = false;
    }

    public void SetPlayerOne()
    {
        PlayerOne.transform.position = PlayerTwo.transform.position;
        PlayerOne.transform.rotation = PlayerTwo.transform.rotation;
        PlayerOne.SetActive(true);
        PlayerTwo.SetActive(false);
        PlayerOne.GetComponent<Animator>().Play("Changer");
        IsChange = true;
    }

     IEnumerator  StartVfx()
     {
        EffectVisual.transform.position = PlayerTwo.transform.position;
        EffectVisual.transform.position = PlayerOne.transform.position;
        EffectVisual.SetActive(true);
        yield return new WaitForSeconds(5);
        EffectVisual.SetActive(false);
     }
}
