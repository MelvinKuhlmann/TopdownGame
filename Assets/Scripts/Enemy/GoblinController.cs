using UnityEngine;

public class GoblinController : Enemy
{
    private Rigidbody2D myRigidbody2D;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    private bool moving;

    public float timeBetweenMove;
    public float timeToMove;

    public override int id => 1;

    public override string name => "Goblin";

    public override int maxHealth => 10;

    public override int experience => 10;

    public override int level => 1;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
    }

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
                moveDirection = new Vector3(Random.Range (-1f, 1f) * moveSpeed, Random.Range(-1f,1f) * moveSpeed, 0f); 
            }
        }
    }

    protected override void PerformAttack()
    {
        throw new System.NotImplementedException();
    }
}
