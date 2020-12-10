using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Equipment/Main Hand Weapon")]
public class MainHand : Item
{
    [Header("Requirements")]
    public int playerLevel = 1;

    [Header("Stats")]
    public int weaponPower;

    public override void Use()
    {
        Debug.Log(string.Format("Equipping weapon: {0}", itemName));
        GetEquipmentController().ChangeMainHand(this);
    }
}
