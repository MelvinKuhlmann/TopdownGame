using System.Collections;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject buyMenu;
    public GameObject sellMenu;
    public TMP_Text shardText;

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
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !shopMenu.activeInHierarchy)
        {
            OpenShop();
        }
    }

    public void OpenShop()
    {
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
    }

    public void OpenSellMenu()
    {
        buyMenu.SetActive(false);
        sellMenu.SetActive(true);
    }
}
