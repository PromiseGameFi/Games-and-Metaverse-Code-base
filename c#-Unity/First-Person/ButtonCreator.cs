using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonParent;
    private List<Button> buttons = new List<Button>();
    private const string BUTTON_COUNT_KEY = "ButtonCount";

    private void Start()
    {
        int count = PlayerPrefs.GetInt(BUTTON_COUNT_KEY, 0);
        count++;
        PlayerPrefs.SetInt(BUTTON_COUNT_KEY, count);

        for (int i = 1; i <= count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent);
            Button btn = newButton.GetComponent<Button>();
            btn.name = "button" + i;
            buttons.Add(btn);
        }
    }
}
