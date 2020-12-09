using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Text countText;

    [SerializeField]
    private Button button;

    public void InitSlotVisualisation(Sprite sprite, string name, int count)
    {
        image.sprite = sprite;
        nameText.text = name;

        UpdateSlotCount(count);
    }

    public void UpdateSlotCount(int count)
    {
        countText.text = count.ToString();
    }

    public void AssignButtonCallback(System.Action onClickCallBack)
    {
        button.onClick.AddListener(() => onClickCallBack());
    }
}
