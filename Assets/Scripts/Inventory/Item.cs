using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public Sprite icon;
    public new string name;
    public string category;
    public string tooltip;
    public bool isQuestItem;

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
