using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject buyMenu;
    public GameObject buyMenuItems;
    public GameObject sellMenu;
    public GameObject sellMenuItems;
    public TMP_Text shardText;
    public GameObject shopItem;

    private List<Item> itemsInShop;

    private ItemButton[] buyItemButtons;
    private ItemButton[] sellItemButtons;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    #region Singleton
    public static ShopUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ShopUI found");
            return;
        }

        instance = this;

        ShopItemEvents.OnItemClick += ItemClicked;
    }
    #endregion

    public void OpenShop(List<Item> itemsToSale)
    {
        itemsInShop = itemsToSale;
        shopMenu.SetActive(true);
        OpenBuyMenu();

        shardText.text = "12322" + "S";  //TODO get shards from player
    }

    public void  CloseShop()
    {
        shopMenu.SetActive(false);
    }

    public void OpenBuyMenu()
    {
        buyMenu.SetActive(true);
        sellMenu.SetActive(false);
        ClearItems(buyMenuItems.transform);


        for (int i = 0; i < itemsInShop.Count; i++)
        {
            GameObject item = Instantiate(shopItem, new Vector3(0, 0, 0), Quaternion.identity);
            item.transform.SetParent(buyMenuItems.transform, false);

            ItemButton itemButton = item.GetComponent<ItemButton>();
            itemButton.itemImage.sprite = itemsInShop[i].icon;
            itemButton.amountText.text = "";
            Debug.Log(string.Format("item added {0}", itemsInShop[i].id));
            itemButton.item = itemsInShop[i];
        }
    }

    void ItemClicked(Item item)
    {
        Debug.Log(string.Format("blaaa: {0}", item.id));
    }

    public void OpenSellMenu()
    {
        buyMenu.SetActive(false);
        sellMenu.SetActive(true);
        ClearItems(sellMenuItems.transform);

        for (int i = 0; i < itemsInShop.Count; i++) // TODO get from inventory instead of NPC
        {
            GameObject item = Instantiate(shopItem, new Vector3(0, 0, 0), Quaternion.identity);
            item.transform.SetParent(sellMenuItems.transform, false);

            ItemButton itemButton = item.GetComponent<ItemButton>();
            itemButton.itemImage.sprite = itemsInShop[i].icon; // TODO get from inventory instead of NPC
            itemButton.amountText.text = "13";
           
        }
    }

    private void ClearItems(Transform parent)
    {
        foreach (Transform child in parent)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
