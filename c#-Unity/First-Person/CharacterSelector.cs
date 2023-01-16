using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characterList;
    public GameObject currentCharacter;
    public int currentCharacterIndex = 0;
    public Button nextButton;
    public Button previousButton;

    private void Start()
    {
        currentCharacter = characterList[currentCharacterIndex];
        nextButton.onClick.AddListener(NextCharacter);
        previousButton.onClick.AddListener(PreviousCharacter);
    }

    public void NextCharacter()
    {
        currentCharacterIndex++;
        if (currentCharacterIndex >= characterList.Length)
        {
            currentCharacterIndex = 0;
        }
        SelectCharacter();
    }

    public void PreviousCharacter()
    {
        currentCharacterIndex--;
        if (currentCharacterIndex < 0)
        {
            currentCharacterIndex = characterList.Length - 1;
        }
        SelectCharacter();
    }

    public void SelectCharacter()
    {
        currentCharacter.SetActive(false);
        currentCharacter = characterList[currentCharacterIndex];
        currentCharacter.SetActive(true);
    }
}
