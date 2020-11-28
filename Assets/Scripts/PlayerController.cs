using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    public int movementSpeed;
    public int jumpHeight;

    private void FixedUpdate()
    {
        HandleKeyboardMovement();
    }

    private void HandleKeyboardMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        GetRigidbody().AddForce(Vector2.left * movementSpeed, ForceMode2D.Force);
    }

    private void MoveRight()
    {
        GetRigidbody().AddForce(Vector2.right * movementSpeed, ForceMode2D.Force);
    }

    private Rigidbody2D GetRigidbody()
    {
        NetworkIdentity netId = NetworkClient.connection.identity;
        return netId.GetComponent<Rigidbody2D>();
    }
}
