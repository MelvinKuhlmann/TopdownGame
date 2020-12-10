using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Equipment/Weapon")]
public class Weapon : Item
{
    [Header("Requirements")]
    public int playerLevel;

    [Header("Stats")]
    public int weaponPower;

    public override void Use()
    {
        Debug.Log(string.Format("Using weapon: {0}", itemName));
    }
}
