using UnityEngine;
using UnityEngine.UI;

public class ButtonParentUI : MonoBehaviour
{
    public float buttonSpacing = 10f;

    private RectTransform rectTransform;
    private VerticalLayoutGroup layoutGroup;
    private ScrollRect scrollRect;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        layoutGroup = GetComponent<VerticalLayoutGroup>();
        scrollRect = GetComponentInParent<ScrollRect>();

        layoutGroup.spacing = buttonSpacing;
    }

    private void Update()
    {
        float height = 0f;
        foreach (RectTransform child in rectTransform)
        {
            height += child.sizeDelta.y + buttonSpacing;
        }
        height = Mathf.Max(0f, height - buttonSpacing);
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);

        if (scrollRect != null)
        {
            scrollRect.enabled = height > scrollRect.GetComponent<RectTransform>().sizeDelta.y;
        }
    }
}
