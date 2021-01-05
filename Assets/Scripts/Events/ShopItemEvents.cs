using UnityEngine;
public class ShopItemEvents : MonoBehaviour
{
    public delegate void OnItemClicked(Item item);
    public static event OnItemClicked OnItemClick;

    public static void ItemClicked(Item item)
    {
        if (OnItemClick != null)
        {
            OnItemClick(item);
        }
    }
}
