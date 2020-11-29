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

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    }

    private void MoveLeft()
    {
        FlipSpriteX(true);
        animator.SetBool("isMoving", true);
        GetRigidbody().AddForce(Vector2.left * movementSpeed, ForceMode2D.Force);
    }

    private void MoveRight()
    {
        FlipSpriteX(false);
        animator.SetBool("isMoving", true);
        GetRigidbody().AddForce(Vector2.right * movementSpeed, ForceMode2D.Force);
    }

    private Rigidbody2D GetRigidbody()
    {
        // NetworkIdentity netId = NetworkClient.connection.identity;
        //      return netId.GetComponent<NetworkRigidbody2D>();
        return GetComponent<Rigidbody2D>();
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
