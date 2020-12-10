using UnityEngine;

public class Item : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private InventoryItem inventoryItem;
    private Sprite sprite;

    public bool isQuestItem;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        // Using the new keyword is appearantly not a good practice; so we use the CreateInstance method with Setters instead.
        inventoryItem = ScriptableObject.CreateInstance<InventoryItem>();
        inventoryItem.SetItemIcon(sprite);
        inventoryItem.SetItemName(gameObject.name);

        InitCollider2D();
    }

    private void InitCollider2D()
    {
        Vector2 spriteBoundsSize = sprite.bounds.size;

        boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        boxCollider2D.size = spriteBoundsSize;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag.Player.ToString()))
        {
            Destroy(gameObject);
            Debug.Log(string.Format("Player picked up {0}", gameObject.name));
            Inventory.instance.Add(inventoryItem);
        }
    }
}
