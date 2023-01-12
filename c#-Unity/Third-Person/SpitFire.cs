using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitFire : MonoBehaviour
{
    public GameObject DragonChar;
    public GameObject FireChar;
    public bool isFire;
    // Start is called before the first frame update
    void Start()
    {
        isFire = true;
        FireChar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) 
        {
            DragonChar.GetComponent<Animator>().Play("Firemouth");
            StartCoroutine(StartTheVfx());
            Invoke("SetFireOff", 5f);
        }
    }

    IEnumerator StartTheVfx()
    {
        yield return new WaitForSeconds(1);
        FireChar.SetActive(true);

    }

    public void SetFireOff()
    {
        FireChar.SetActive(false);
    }
}
