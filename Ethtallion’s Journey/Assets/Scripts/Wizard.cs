using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    //Speed
    public float speed;
    private float speedUp;
    [SerializeField] [Range(0, 4)] private float maxSpeed;
    Vector2 velocity;

    //Direction
    private float direction;

    //Stats
    public int health;
    [SerializeField] [Range(0, 4)] private float jumpSpeed;
    [SerializeField] [Range(0, 2)] private float jumpDuration;
    private float jumpTick;
    public bool isJumping;

    //Components
    public Rigidbody2D myRigidBody;
    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D myBoxCollider2D;
    private LayerMask blockingLayer;

    //Target
    public GameObject finish;

    //Singleton
    public static Wizard instance;

    Vector2 modifier;


    public static Wizard GetInstance()
    {
        return instance;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Singleton
        instance = this;

        //Get Components
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        blockingLayer = LayerMask.GetMask("Wall");

        //Init variables
        speedUp = 0.25f;
        //maxSpeed = 2f;
        direction = 1f;
        health = 10;
        jumpTick += jumpDuration;

        modifier = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<BoxCollider2D>().IsTouching(finish.GetComponent<BoxCollider2D>()))
        {
            //the level is completed. put tha code here
            Debug.Log("We hit it.");
        }


        //When hit a wall, reduce speed and turn around
        if (DetectObs())
        {
            Debug.Log("Obs");
            speed = 0.5f;
            direction = -direction;
            mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
        }

        //Gust behavior
        if (isJumping)
        {
            if(jumpTick > 0)
            {
                Jump();
                jumpTick -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                jumpTick = 0;
                jumpTick += jumpDuration;
            }
        }

        //if lower than max speed, speed up, else use max speed
        if (velocity.magnitude < maxSpeed)
        {
            //speed += Time.deltaTime * speedUp;
            velocity += new Vector2(speedUp * direction, 0);
        }
        else
        {
            //speed = maxSpeed;
            velocity = new Vector2(maxSpeed * direction, 0);
        }

        velocity = velocity + modifier;
        myRigidBody.velocity = velocity;
    }

    public void MovementModifier(Vector2 mod)
    {
        modifier = mod;
    }

    protected bool DetectObs()
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(direction * myBoxCollider2D.bounds.extents.x * 1.1f, 0);
        Debug.DrawLine(start, end);

        myBoxCollider2D.enabled = false;

        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);

        myBoxCollider2D.enabled = true;

        if(hit.transform == null)
        {
            return false;
        }

        Debug.Log("Hit!");
        return true;
    }

    protected bool DetectGround()
    {
        Vector2 start = transform.position;
        Vector2 end = start - new Vector2(0, myBoxCollider2D.bounds.extents.y * 1.1f);
        Debug.DrawLine(start, end);

        myBoxCollider2D.enabled = false;

        //RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, myBoxCollider2D.bounds.extents, 0.0f, new Vector2(direction, 0));
        myBoxCollider2D.enabled = true;

        if (hit.transform == null)
        {
            return false;
        }

        Debug.Log("Grounded!");
        return true;
    }

    protected void Jump()
    {
        if (DetectObs())
        {
            speed = 0.5f;
            direction = -direction;
            mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
        }

        myRigidBody.MovePosition((Vector2)transform.position + new Vector2(0, 1f * Time.deltaTime * jumpSpeed) + new Vector2(velocity.magnitude * direction, 0) * Time.deltaTime);
    }
}
