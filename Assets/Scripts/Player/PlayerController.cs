using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PlayerController found");
            return;
        }

        instance = this;
    }
    #endregion

    private Player player;
    private PlayerAnimationController playerAnimationController;

    private new Rigidbody2D rigidbody2D;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    private void Start()
    {
        player = Player.instance;
        playerAnimationController = PlayerAnimationController.instance;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimationController.ChangeAnimation("isSlashing");
        }
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        playerAnimationController.HandleMovementAnimations(horizontal, vertical);

        rigidbody2D.velocity = new Vector2(horizontal * player.movementSpeed, vertical * player.movementSpeed);
    }
}
