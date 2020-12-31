using UnityEngine;

public class ToggleableUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public void Hide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
}
