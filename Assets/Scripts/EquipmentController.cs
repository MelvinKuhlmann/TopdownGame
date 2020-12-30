using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class EquipmentController : MonoBehaviour
{
    #region Singleton
    public static EquipmentController instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    #endregion

    public Item currentHelmet;
    public Item currentChestPiece;
    public MainHand currentMainHand;
    public Item currentOffHand;

    public GameObject helmet;
    public GameObject chestPiece;
    public GameObject mainHand;
    public GameObject offHand;

    private Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
    }

    public void ChangeHelmet(Item newHelmet)
    {
        mainHand.GetComponent<SpriteResolver>().SetCategoryAndLabel("Head", newHelmet.name.Replace(" ", "_"));
        inventory.Remove(newHelmet);
        inventory.Add(currentHelmet);
        currentHelmet = newHelmet;
    }
    public void ChangeChestPiece(Item newChestPiece)
    {
        mainHand.GetComponent<SpriteResolver>().SetCategoryAndLabel("Body", newChestPiece.name.Replace(" ", "_"));
        inventory.Remove(newChestPiece);
        inventory.Add(currentChestPiece);
        currentChestPiece = newChestPiece;
    }

    public void ChangeMainHand(Item newMainHand)
    {
        mainHand.GetComponent<SpriteResolver>().SetCategoryAndLabel("Main_Hand", newMainHand.name.Replace(" ", "_"));
        inventory.Remove(newMainHand);
        inventory.Add(currentMainHand);
        currentMainHand = (MainHand) newMainHand;
        Player.instance.UpdateStats();
    }

    public void ChangeOffHand(Item newOffHand)
    {
        mainHand.GetComponent<SpriteResolver>().SetCategoryAndLabel("Off_Hand", newOffHand.name.Replace(" ", "_"));
        inventory.Remove(newOffHand);
        inventory.Add(currentOffHand);
        currentOffHand = newOffHand;
    }

}
