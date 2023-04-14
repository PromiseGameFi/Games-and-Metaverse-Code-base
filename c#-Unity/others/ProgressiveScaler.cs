using UnityEngine;

public class ProgressiveScaler : MonoBehaviour
{
    public float expansionSize = 2f; // set the expansion size in the Unity Editor
    public float expansionRate = 0.1f; // set the percentage of expansion per second in the Unity Editor

    private float currentScale;
    private float targetScale;

    private void Awake()
    {
        currentScale = transform.localScale.x;
        targetScale = currentScale * expansionSize;
    }

    private void Update()
    {
        if (currentScale < targetScale)
        {
            float scaleIncrease = expansionRate * currentScale * Time.deltaTime;
            currentScale += scaleIncrease;
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
    }
}
