using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Equipment/Main Hand")]
public class MainHand : Item
{
    [Header("Requirements")]
    public int playerLevel = 1;

    [Header("Stats")]
    public int weaponPower;

    public override void Use()
    {
        Debug.Log(string.Format("Equipping main hand: {0}", name));
        GetEquipmentController().ChangeMainHand(this);
    }
}
