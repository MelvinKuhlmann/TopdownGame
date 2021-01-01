using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text amountText;
    public Item item;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Press);
    }

    void Press()
    {
        ShopItemEvents.ItemClicked(item);
    }
}
