using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Player found");
            return;
        }

        instance = this;
    }
    #endregion

    private EquipmentController equipmentController;

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
    public int baseWeaponPower;
    public int totalWeaponPower;
    public int armorPower = 1;
    public float movementSpeed = 5.0f;

    private void Start()
    {
        equipmentController = EquipmentController.instance;

        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;
        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }

        SetBaseStats();

        UpdateStats();
    }

    private void SetBaseStats()
    {
        baseWeaponPower = 1;
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
        HackExp();

        //Keep player inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    // TODO: Fix this, because its a bit weird the equipment controller first goes to the player, then back.
    public void UpdateStats()
    {
        totalWeaponPower = baseWeaponPower + equipmentController.currentMainHand.weaponPower;
    }

    /**
     * Set the boundaries of the map, to make sure the player cannot go beyond the borders of the game scene
     */
    public void SetBoundaries(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(mapBoundaryOffset, mapBoundaryOffset, 0f);
        topRightLimit = topRight + new Vector3(mapBoundaryOffset * -1, mapBoundaryOffset * -1, 0f);
    }
}
