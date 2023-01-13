using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTo : MonoBehaviour
{
    public Collider Shadow;
    public Collider Talk;
    public GameObject TheText;
    public MonoBehaviour BasicBehave;
    public MonoBehaviour cameramove;
    public bool ScriptOff;
    // Start is called before the first frame update
    void Start()
    {
        Shadow= GetComponent<Collider>();
        Talk= GetComponent<Collider>();
        TheText.SetActive(false);
        ScriptOff = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Z) && ScriptOff) 
        {
            BasicBehave.enabled= false;
            cameramove.enabled= false;
            ScriptOff=false;
        }
        else if(Input.GetKeyUp(KeyCode.Z) && !ScriptOff) 
        {
            BasicBehave.enabled= true;
            cameramove.enabled= true;
            ScriptOff = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Shadow.bounds.Intersects(Talk.bounds))
        {
            Debug.Log("It inside");
            TheText.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Shadow.bounds.Intersects(Talk.bounds))
        {
            Debug.Log("It Outside");
            TheText.SetActive(false);
        }
    }
}
