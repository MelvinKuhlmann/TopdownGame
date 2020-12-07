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

    [Header("Player Stats")]
    public string playerName;
    public int playerLevel = 1;
    public int currentExp = 0;
    public int[] expToNextLevel;
    public int baseExp = 1000;
    public int maxLevel = 100;
    public int currentHp;
    public int maxHp = 100;
    public int currentMp;
    public int maxMp = 50;
    public int strength;
    public int defense;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<CameraController>().SetPlayer(this);
    }

    private void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;
        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;
        if (playerLevel < maxLevel)
        {
            if (currentExp > expToNextLevel[playerLevel])
            {
                //removes exp to the next level, so if you are at 10, and need to be at 20 for next level, and you receive 15, you will start at the next level with 5 exp.
                currentExp -= expToNextLevel[playerLevel];
                playerLevel++;

                //determine whether to add to str or def based on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defense++;
                }

                maxHp += 5;
                currentHp = maxHp;

                maxMp += 2;
                currentMp = maxMp;
            }
        }
        if (playerLevel >= maxLevel)
        {
            currentExp = 0;
        }
    }

    private void HackExp()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            AddExp(500);
        }
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        HackExp();

        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeAnimation("isSlashing");
        }

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

        HandleMovementAnimations();

        GetRigidbody().velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    public void SlashEnd()
    {
        Debug.Log(" Comes here");
        ChangeAnimation("isIdle");
    }

    //TODO: Clean code up, it's too messy.
    private void HandleMovementAnimations()
    {
        if (horizontal == 0 && vertical == 0 && animator.GetBool("isSlashing") == false)
        {
            ChangeAnimation("isIdle");
        } else {
            if (horizontal != 0 && animator.GetBool("isSlashing") == false)
            {
                if (horizontal < 0)
                {
                    ChangeAnimation("isMovingLeft");
                }
                else
                {
                    ChangeAnimation("isMovingRight");
                }
            }
            if (vertical != 0 && animator.GetBool("isSlashing") == false)
            {
                if (vertical < 0)
                {
                    ChangeAnimation("isMovingDown");
                }
                else
                {
                    ChangeAnimation("isMovingUp");
                }
            }
        }
    }

    private void ChangeAnimation(string animationFlag, bool resetAll = true) 
    {
        if (resetAll)
        {
            ResetAnimationParameters();
        }
        animator.SetBool(animationFlag, true);
    }

    private void ResetAnimationParameters()
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
    }

    private Rigidbody2D GetRigidbody()
    {
        NetworkIdentity netId = NetworkClient.connection.identity;
        return netId.GetComponent<Rigidbody2D>();
    }
}
