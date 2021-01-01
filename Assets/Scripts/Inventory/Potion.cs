using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Potion")]
public class Potion : Item
{
    public enum potionType { Health, Mana};

    [Header("Requirements")]
    public int playerLevel = 1;

    [Header("Restores")]
    public int restorePoints;
    public potionType type;
    public int coolDownPeriod;
}
