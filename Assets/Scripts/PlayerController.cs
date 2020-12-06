using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    public float movementSpeed = 5.0f;
    public Animator animator;

    private readonly float mapBoundaryOffset = 0.5f;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private void Start()
    {
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

        //Keep player inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    /**
     * Set the boundaries of the map, to make sure the player cannot go beyond the borders of the game scene
     */
    public void SetBoundaries(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(mapBoundaryOffset, mapBoundaryOffset, 0f);
        topRightLimit = topRight + new Vector3(mapBoundaryOffset * -1, mapBoundaryOffset * -1, 0f);
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
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingUp", false);
        } else
        {
            if (horizontal != 0)
            {
                animator.SetBool("isMovingDown", false);
                animator.SetBool("isMovingUp", false);
                if (horizontal < 0)
                {
                    animator.SetBool("isMovingLeft", true);
                    animator.SetBool("isMovingRight", false);
                }
                else
                {
                    animator.SetBool("isMovingRight", true);
                    animator.SetBool("isMovingLeft", false);
                }
            }
            if (vertical != 0)
            {
                animator.SetBool("isMovingLeft", false);
                animator.SetBool("isMovingRight", false);
                if (vertical < 0)
                {
                    animator.SetBool("isMovingDown", true);
                    animator.SetBool("isMovingUp", false);
                }
                else
                {
                    animator.SetBool("isMovingDown", false);
                    animator.SetBool("isMovingUp", true);
                }
            }
        }

        GetRigidbody().velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    private Rigidbody2D GetRigidbody()
    {
        NetworkIdentity netId = NetworkClient.connection.identity;
        return netId.GetComponent<Rigidbody2D>();
    }
}
