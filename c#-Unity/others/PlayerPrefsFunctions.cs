using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyValueStorage : MonoBehaviour
{
    public InputField keyInputField;
    public InputField valueInputField;

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

        
    }

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

    public void DeleteValue()
    {
        if (PlayerPrefs.HasKey(keyInputField.text))
        {
            PlayerPrefs.DeleteKey(keyInputField.text);
            Debug.Log(keyInputField.text+ " " + "deleted successfully");
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
