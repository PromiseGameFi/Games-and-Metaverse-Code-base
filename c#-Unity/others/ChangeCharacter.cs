using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public GameObject EffectVisual;
    public GameObject EffectVisual2;
    public bool IsChange;
    // Start is called before the first frame update
    void Start()
    {
        PlayerOne.SetActive(true);
        PlayerTwo.SetActive(false);
        EffectVisual.SetActive(false);
        EffectVisual2.SetActive(false);
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
            StartCoroutine(EndVFXone());

        }
        else if(Input.GetKeyDown(KeyCode.B) && !IsChange)
        {
            StartCoroutine(StartVfxTwo());
            PlayerTwo.GetComponent<Animator>().Play("Change");
            IsChange = true;
            Invoke("SetPlayerOne", 1f);
            StartCoroutine(EndVFXone());
            
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
        
        EffectVisual.transform.position = PlayerOne.transform.position;
        
        EffectVisual2.transform.position = PlayerOne.transform.position;
        
        yield return new WaitForSeconds(1);
        EffectVisual.SetActive(true);
        EffectVisual2.SetActive(true);
    }

    IEnumerator StartVfxTwo()
    {
        EffectVisual.transform.position = PlayerTwo.transform.position;
        
        EffectVisual2.transform.position = PlayerTwo.transform.position;
      
        
        yield return new WaitForSeconds(1);
        EffectVisual.SetActive(true);
        EffectVisual2.SetActive(true);
    }

    IEnumerator EndVFXone()
    {
        yield return new WaitForSeconds(5);
        EffectVisual.SetActive(false);
        EffectVisual2.SetActive(false);
    }




}
