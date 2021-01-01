using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public Sprite icon;
    public new string name;
    public InventoryCategory category;
    public string description;
    public bool isQuestItem;
    public bool isStackable;
    public int buyValue;
    public int sellValue;

    public virtual void Use()
    {
        Debug.Log(string.Format("Using item: {0}", name));
    }

    public EquipmentController GetEquipmentController()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        return player.GetComponent<EquipmentController>();
    }
}
