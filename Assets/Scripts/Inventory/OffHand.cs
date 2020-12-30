using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Equipment/Off Hand")]
public class OffHand : Item
{
    [Header("Requirements")]
    public int playerLevel = 1;

    [Header("Stats")]
    public int weaponPower;
    public int armorPower;

    public override void Use()
    {
        Debug.Log(string.Format("Equipping off hand: {0}", name));
        GetEquipmentController().ChangeOffHand(this);
    }
}
