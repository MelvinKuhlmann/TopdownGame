using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class EquipmentController : MonoBehaviour
{
    public Item currentHelmet;
    public Item currentChestPiece;
    public MainHand currentMainHand;
    public Item currentOffHand;

    public GameObject helmet;
    public GameObject chestPiece;
    public GameObject mainHand;
    public GameObject offHand;
   
    public InventoryController inventoryController;

    public void ChangeHelmet(Item newHelmet)
    {
        mainHand.GetComponent<SpriteResolver>().SetCategoryAndLabel("Head", newHelmet.itemName.Replace(" ", "_"));
        inventoryController.Remove(newHelmet);
        inventoryController.Add(currentHelmet);
        currentHelmet = newHelmet;
    }
    public void ChangeChestPiece(Item newChestPiece)
    {
        mainHand.GetComponent<SpriteResolver>().SetCategoryAndLabel("Body", newChestPiece.itemName.Replace(" ", "_"));
        inventoryController.Remove(newChestPiece);
        inventoryController.Add(currentChestPiece);
        currentChestPiece = newChestPiece;
    }

    public void ChangeMainHand(Item newMainHand)
    {
        mainHand.GetComponent<SpriteResolver>().SetCategoryAndLabel("Main_Hand", newMainHand.itemName.Replace(" ", "_"));
        inventoryController.Remove(newMainHand);
        inventoryController.Add(currentMainHand);
        currentMainHand = (MainHand) newMainHand;
    }

    public void ChangeOffHand(Item newOffHand)
    {
        mainHand.GetComponent<SpriteResolver>().SetCategoryAndLabel("Off_Hand", newOffHand.itemName.Replace(" ", "_"));
        inventoryController.Remove(newOffHand);
        inventoryController.Add(currentOffHand);
        currentOffHand = newOffHand;
    }

}
