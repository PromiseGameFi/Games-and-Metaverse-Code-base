using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Add the Change Character Script in this Folder
    public ChangeCharacter script;
    public GameObject EffectAttack;
    public GameObject SpawnPoint;
    public GameObject SpawnPointTwo;
    
    // Start is called before the first frame update
    void Start()
    {
        EffectAttack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N) && script.IsChange) 
        {
            script.PlayerOne.GetComponent<Animator>().Play("Attack");
            EffectAttack.transform.position = SpawnPoint.transform.position;
            EffectAttack.transform.rotation = SpawnPoint.transform.rotation;
            StartCoroutine(ShootLaserOne());
            EffectAttack.SetActive(false);
            
        }
        else if(Input.GetKeyDown(KeyCode.N) && !script.IsChange)
        {
            script.PlayerTwo.GetComponent<Animator>().Play("Attack");
            EffectAttack.transform.position = SpawnPointTwo.transform.position;
            EffectAttack.transform.rotation = SpawnPointTwo.transform.rotation;
            StartCoroutine(ShootLaserTwo());
            EffectAttack.SetActive(false);
        }
    }

    
    IEnumerator ShootLaserOne()
    {
        yield return new WaitForSeconds(1);
        EffectAttack.SetActive(true);
    }
    IEnumerator ShootLaserTwo()
    {
        yield return new WaitForSeconds(1);
        EffectAttack.SetActive(true);
    }
}
