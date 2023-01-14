using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class CharacterSelectUI : MonoBehaviour
{
    public GameObject[] characters;
    public Button selectButton;
    public int currentIndex = 0;
    private float rotationSpeed = 90.0f;
    private bool isRotating = false;
    public float mouseX;
    void Start()
    {
        selectButton.onClick.AddListener(SelectCharacter);
        ShowCharacter(currentIndex);
    }

    public void NextCharacter()
    {
        currentIndex++;
        if (currentIndex >= characters.Length)
        {
            currentIndex = 0;
        }
        ShowCharacter(currentIndex);
    }

    public void PreviousCharacter()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = characters.Length - 1;
        }
        ShowCharacter(currentIndex);
    }

    void ShowCharacter(int index)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
    }

    void SelectCharacter()
    {
        SceneManager.LoadScene("NextScene");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            characters[currentIndex].transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        
            if (Input.GetMouseButton(0))
            {
                mouseX += Input.GetAxis("Mouse X");
                //mouseY -= Input.GetAxis("Mouse Y");
                characters[currentIndex].transform.eulerAngles = new Vector3(0, mouseX, 0);
            }
        
    }
}
