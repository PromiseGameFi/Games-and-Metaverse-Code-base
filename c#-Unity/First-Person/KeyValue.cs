using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyValueStorage : MonoBehaviour
{
    public InputField keyInputField;
    public InputField valueInputField;

    //Second Part
    public GameObject buttonPrefab;
    public Transform buttonParent;
    private List<Button> buttons = new List<Button>();
    private const string BUTTON_COUNT_KEY = "ButtonCount";
    public int CountNumber;


    public void GetButtons()
    {
        
        for (int i = 1; i <= PlayerPrefs.GetInt(BUTTON_COUNT_KEY); i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent);
            Button btn = newButton.GetComponent<Button>();
            btn.name = "key" + i;
            btn.GetComponentInChildren<Text>().text =  PlayerPrefs.GetString("key" + i);
            buttons.Add(btn);
        }

        CountNumber = PlayerPrefs.GetInt(BUTTON_COUNT_KEY);
    }
    public void StoreValue()
    {
        if (PlayerPrefs.HasKey(keyInputField.text))
        {
            Debug.Log("A URL with this name already exists.");
            return;
        }
        
        PlayerPrefs.SetString(keyInputField.text, valueInputField.text);
        PlayerPrefs.Save();
        Debug.Log("Value stored successfully");

        StartButton();



    }

    /**public void Update()
    {
        UpdateButtons();
    }*/
    public void GetValue()
    {
        if (PlayerPrefs.HasKey(keyInputField.text))
        {
            string value = PlayerPrefs.GetString(keyInputField.text);
            Debug.Log("Value for key '" + keyInputField.text + "' is: " + value);
        }
        else
        {
            Debug.Log("Key not found in storage");
        }
    }

    private void StartButton()
    {
        
        int count = PlayerPrefs.GetInt(BUTTON_COUNT_KEY, 0);
        count++;
        PlayerPrefs.SetInt(BUTTON_COUNT_KEY, count);
        //Buttons Name
        PlayerPrefs.SetString("button"+count, valueInputField.text);
        PlayerPrefs.SetString("key" + count, keyInputField.text);

        /**GameObject newButton = Instantiate(buttonPrefab, buttonParent);
        Button btn = newButton.GetComponent<Button>();
        btn.name = keyInputField.text;
        //btn.text = "keyInputField.text";
        btn.GetComponentInChildren<Text>().text = keyInputField.text; 
        buttons.Add(btn);
        */

        //PlayerPrefs.SetInt("CountValue", CountNumber);

    }

    private void UpdateButtons()
    {
        int count = PlayerPrefs.GetInt(BUTTON_COUNT_KEY, 0);

        for (int i = 0; i < count; i++)
        {
            string key = BUTTON_COUNT_KEY + i;
            if (PlayerPrefs.HasKey(key))
            {
                GameObject newButton = Instantiate(buttonPrefab, buttonParent);
                
            }
        }
    }

    public void DeleteValue()
    {
        if (PlayerPrefs.HasKey(keyInputField.text))
        {
            PlayerPrefs.DeleteKey(keyInputField.text);
            Debug.Log(keyInputField.text + " " + "deleted successfully");
        }
        else
        {
            Debug.Log("Key not found in storage");
        }
    }
    public void DeleteAllValues()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All values deleted successfully");
    }

}



/**using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyValueStorage : MonoBehaviour
{
    private Dictionary<string, string> storage = new Dictionary<string, string>();
    public InputField keyInputField;
    public InputField valueInputField;

    public void StoreValue()
    {
        storage[keyInputField.text] = valueInputField.text;
        Debug.Log("Value stored successfully");
    }

    public void GetValue()
    {
        if (storage.ContainsKey(keyInputField.text))
        {
            string value = storage[keyInputField.text];
            Debug.Log("Value for key '" + keyInputField.text + "' is: " + value);
        }
        else
        {
            Debug.Log("Key not found in storage");
        }
    }

}*/

