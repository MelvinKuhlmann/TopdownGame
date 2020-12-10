using UnityEngine;
using UnityEditor;

public class PickupableObject : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Sprite sprite;
    public Item item;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

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
            InventoryController.instance.Add(item);
        }
    }
}
