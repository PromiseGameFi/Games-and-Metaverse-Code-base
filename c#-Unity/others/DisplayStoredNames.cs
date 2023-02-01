using UnityEngine;
using UnityEngine.UI;

public class DisplayStoredNames : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentParent;

    private void Start()
    {
        DisplayNames();
    }

    private void DisplayNames()
    {
        foreach (string name in PlayerPrefs.GetAllKeys())
        {
            GameObject buttonGO = Instantiate(buttonPrefab, contentParent);
            Button button = buttonGO.GetComponent<Button>();
            button.GetComponentInChildren<Text>().text = name;

            button.onClick.AddListener(() => OpenURL(name));
        }
    }

    private void OpenURL(string name)
    {
        string url = PlayerPrefs.GetString(name);
        Application.OpenURL(url);
    }
}
