using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    [Header("Windows")]
    public GameObject shopMenu;
    public GameObject buyMenu;
    public GameObject buyMenuItems;
    public GameObject sellMenu;
    public GameObject sellMenuItems;

    [Header("Money")]
    public TMP_Text shardText;

    [Header("Item Prefab")]
    public GameObject shopItem;

    [Header("Selected Buy Item")]
    public TMP_Text buyItemName;
    public TMP_Text buyItemDescription;
    public TMP_Text buyItemValue;

    [Header("Selected Sell Item")]
    public TMP_Text sellItemName;
    public TMP_Text sellItemDescription;
    public TMP_Text sellItemValue;

    private List<Item> itemsInShop;
    private Item selectedItem;

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

        ShopItemEvents.OnItemClick += ItemSelected;
    }
    #endregion

    public void OpenShop(List<Item> itemsToSale)
    {
        itemsInShop = itemsToSale;
        shopMenu.SetActive(true);
        OpenBuyMenu();
        UpdatePlayerTotalShards();
    }

    public void  CloseShop()
    {
        shopMenu.SetActive(false);
    }

    public void OpenBuyMenu()
    {
        buyMenu.SetActive(true);
        sellMenu.SetActive(false);
        selectedItem = null;
        ClearItems(buyMenuItems.transform);

        SelectBuyItem(itemsInShop[0]);

        for (int i = 0; i < itemsInShop.Count; i++)
        {
            GameObject item = Instantiate(shopItem, new Vector3(0, 0, 0), Quaternion.identity);
            item.transform.SetParent(buyMenuItems.transform, false);

            ItemButton itemButton = item.GetComponent<ItemButton>();
            itemButton.itemImage.sprite = itemsInShop[i].icon;
            itemButton.amountText.text = "";
            itemButton.item = itemsInShop[i];
        }
    }

    public void OpenSellMenu()
    {
        buyMenu.SetActive(false);
        sellMenu.SetActive(true);
        selectedItem = null;

        ShowSellItems();
    }

    private void ShowSellItems()
    {
        ClearItems(sellMenuItems.transform);
        if (Inventory.instance.items.Count >= 1)
        {
            SelectSellItem(Inventory.instance.items[0]);

            for (int i = 0; i < Inventory.instance.items.Count; i++) 
            {
                GameObject item = Instantiate(shopItem, new Vector3(0, 0, 0), Quaternion.identity);
                item.transform.SetParent(sellMenuItems.transform, false);

                ItemButton itemButton = item.GetComponent<ItemButton>();
                itemButton.itemImage.sprite = Inventory.instance.items[i].icon; 
                itemButton.amountText.text = "13";
                itemButton.item = Inventory.instance.items[i];
            }
        }
    }

    private void ClearItems(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    void ItemSelected(Item item)
    {
        if (buyMenu.activeInHierarchy)
        {
            SelectBuyItem(item);
        }

        if (sellMenu.activeInHierarchy)
        {
            SelectSellItem(item);
        }
    }

    void SelectBuyItem(Item item)
    {
        selectedItem = item;
        buyItemName.text = item.name;
        buyItemDescription.text = item.description;
        buyItemValue.text = string.Format("Value: {0}s",item.buyValue);
    }

    void SelectSellItem(Item item)
    {
        selectedItem = item;
        sellItemName.text = item.name;
        sellItemDescription.text = item.description;
        sellItemValue.text = string.Format("Value: {0}s", item.sellValue);
    }

    public void BuyItem()
    {
        if (selectedItem != null)
        {
            if (Inventory.instance.shards >= selectedItem.buyValue)
            {
                Inventory.instance.shards -= selectedItem.buyValue;
                Inventory.instance.Add(selectedItem);
                UpdatePlayerTotalShards();
            }
        }
    }

    public void SellItem()
    {
        if (selectedItem != null)
        {
            Inventory.instance.shards += selectedItem.sellValue;
            Inventory.instance.Remove(selectedItem);
            //TODO determine which items should be selected after selling one, by default it goes now to the first item
            ShowSellItems();
            UpdatePlayerTotalShards();
        }
    }

    void UpdatePlayerTotalShards()
    {
        shardText.text = string.Format("{0}s", Inventory.instance.shards);
    }
}
