using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private Sprite sprite;
    public Item item;
    private Animator itemAnimator;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        // Add animator at runtime
        itemAnimator = gameObject.AddComponent<Animator>();
        // IMPORTANT: Assets in the Resources folder are the ones exposed through Resources.Load
        itemAnimator.runtimeAnimatorController = Resources.Load("Animations/Item/ItemController") as RuntimeAnimatorController;
        itemAnimator.applyRootMotion = true;

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
            Inventory.instance.Add(item);
        }
    }
}
