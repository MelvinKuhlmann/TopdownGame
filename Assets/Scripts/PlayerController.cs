using Mirror;
using System;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    // Temporary variable to check when running animation should stop; we have to change this to states later.
    private int lowSpeed = 3;

    public int movementSpeed;
    public int jumpHeight;
    public Animator animator;
    public bool isGrounded;

    private void Start()
    {
        isGrounded = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraController>().SetPlayer(this);
    }

    private void FixedUpdate()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        if (GetRigidbody().velocity.magnitude <= lowSpeed)
        {
            animator.SetBool("isMoving", false);
        }

        HandleKeyboardMovement();
    }

    private void HandleKeyboardMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    private void MoveLeft()
    {
        FlipSpriteX(true);
        animator.SetBool("isMoving", true);

        Vector3 target = new Vector3();
        target.x = transform.position.x - movementSpeed;
        target.y = transform.position.y;
        GetRigidbody().transform.position = Vector3.Lerp(transform.position, target, 1 * Time.deltaTime);
    }

    private void MoveRight()
    {
        FlipSpriteX(false);
        animator.SetBool("isMoving", true);

        Vector3 target = new Vector3();
        target.x = transform.position.x + movementSpeed;
        target.y = transform.position.y;
        GetRigidbody().transform.position = Vector3.Lerp(transform.position, target, 1 * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            GetRigidbody().velocity += jumpHeight * Vector2.up;
        }
    }

    #region Collision Detection
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Tag.FLOOR.ToString().Equals(other.gameObject.tag))
        {
            if (!isGrounded)
            {
                Debug.LogFormat("player landed");
            }
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (Tag.FLOOR.ToString().Equals(other.gameObject.tag))
        {
            Debug.LogFormat("player falling");
            isGrounded = false;
        }
    }
    #endregion

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
