using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour
{
    public Color normalColor; // The original color of the button
    public Color hoverColor; // The color of the button when hovered over
    public Color clickedColor; // The color of the button when clicked
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.image.color = normalColor; // Assign the Colour
    }

    void OnMouseEnter()
    {
        button.image.color = hoverColor; // Change the color of the button when hovered over
    }

    void OnMouseExit()
    {
        button.image.color = normalColor; // Change the color of the button back to the original color
    }

    void OnMouseDown()
    {
        button.image.color = clickedColor; // Change the color of the button when clicked
    }
}
