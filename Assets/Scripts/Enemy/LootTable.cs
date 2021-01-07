using UnityEngine;

public class LootTable : MonoBehaviour
{
    public Item[] basicLoot;
    public Item[] rareLoot;
    public Item[] uniqueLoot;

    public int silver;

    public float uniqueDropChance = 0.5F; // Default
    public float rareDropChance = 15F; // Default

    public void DropItem()
    {
        double randomNumber = System.Math.Round(Random.Range(0.000F, 100F), 2);

        if (randomNumber <= uniqueDropChance)
        {
            Debug.Log(string.Format("Rolled: {0}. Dropping unique loot.", randomNumber));
            Drop(uniqueLoot[Random.Range(0, uniqueLoot.Length)]);
        } else if (randomNumber <= 15)
        {
            Debug.Log(string.Format("Rolled: {0}. Dropping rare loot.", randomNumber));
            Drop(rareLoot[Random.Range(0, rareLoot.Length)]);
        }

        Debug.Log(string.Format("Rolled: {0}. Dropping basic loot.", randomNumber));
        Drop(basicLoot[Random.Range(0, basicLoot.Length)]);
    }

    public void DropSilver()
    {
        // TODO: Instantiate silver on the floor
    }

    private void Drop(Item item)
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<SpriteRenderer>().sprite = item.icon;
        gameObject.AddComponent<PickupableObject>().item = item;
        gameObject.name = item.name;
        gameObject.transform.position = new Vector3(transform.position.x + Random.Range(0, 1F), transform.position.y + Random.Range(0, 1F), transform.position.z);

        //Instantiate(gameObject, new Vector2(), Quaternion.identity);
    }
}
