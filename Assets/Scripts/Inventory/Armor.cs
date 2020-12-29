using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Equipment/Armor")]
public class Armor : Item
{
    [Header("Requirements")]
    public int playerLevel = 1;

    [Header("Stats")]
    public int armorPower;

    public override void Use()
    {
        Debug.Log(string.Format("Using armor: {0}", itemName));
    }
}
