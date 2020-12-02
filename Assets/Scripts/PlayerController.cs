using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float movementSpeed = 5.0f;

    public Animator animator;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraController>().SetPlayer(this);
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("isMoving", false);
        } else
        {
            animator.SetBool("isMoving", true);
            if (horizontal < 0)
            {
                FlipSpriteX(true);
            } else
            {
                FlipSpriteX(false);
            }
        }

        GetRigidbody().velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    private Rigidbody2D GetRigidbody()
    {
        NetworkIdentity netId = NetworkClient.connection.identity;
        return netId.GetComponent<Rigidbody2D>();
    }

    // Client makes sure this function is only executed on clients
    // If called on the server it will throw an warning
    [Client]
    private void FlipSpriteX(bool flip)
    {
        // Only go on for the LocalPlayer
        if (!isLocalPlayer) return;

        // Make the change local on this client
        spriteRenderer.flipX = flip;

        // Invoke the change on the Server as you already named the function
        CmdProvideFlipStateToServer(spriteRenderer.flipX);
    }

    [Command]
    void CmdProvideFlipStateToServer(bool state)
    {
        // Make the change local on the server
        spriteRenderer.flipX = state;

        // Forward the change also to all clients
        RpcSendFlipState(state);
    }

    // Invoked by the server only but executed on ALL clients
    [ClientRpc]
    void RpcSendFlipState(bool state)
    {
        // Skip this function on the LocalPlayer 
        // because he is the one who originally invoked this
        if (isLocalPlayer) return;

        // Make the change local on all clients
        spriteRenderer.flipX = state;
    }
}
