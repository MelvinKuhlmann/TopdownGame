using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour, IEnemy
{
    public int currentHealth;
    public int maxHealth;
    public int ID { get; set; }
    public int experience { get; set; }

    public float movespeed;
    private Rigidbody2D myRigidbody2D;

    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody2D.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }

        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody2D.velocity = Vector2.zero;

            if(timeBetweenMoveCounter< 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector3(Random.Range (-1f, 1f) * movespeed, Random.Range(-1f,1f) * movespeed, 0f); 
            }
        }
    }

    public void Die()
    {
        Debug.Log("Enemy die");
        CombatEvents.EnemyDied(this);
    }

    public void PerformAttack()
    {
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }


}
