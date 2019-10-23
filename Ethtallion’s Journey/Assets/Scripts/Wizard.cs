using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    //Speed
    public float speed;
    private float speedUp;
    private float maxSpeed;

    //Direction
    private float direction;

    //Stats
    public int health;

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

        instance = this;

        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBoxCollider2D = gameObject.GetComponent<BoxCollider2D>();


        myRigidBody.AddForce(new Vector2(speed, 0));

        speedUp = 0.5f;
        maxSpeed = 2f;
        direction = 1f;
        health = 10;

        modifier = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //When hit a wall, reduce speed and turn around
        if (myRigidBody.GetRelativePointVelocity(transform.position) == Vector2.zero)
        {
            speed = 0.5f;
            direction = -direction;
            mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
        }

        if (GetComponent<BoxCollider2D>().IsTouching(finish.GetComponent<BoxCollider2D>()))
        {
            //the level is completed. put tha code here
            Debug.Log("We hit it.");
        }


        //if lower than max speed, speed up, else use max speed
        if (speed < maxSpeed)
        {
            speed += Time.deltaTime * speedUp;
        }
        else
        {
            speed = maxSpeed;
        }




        //******New Method******
        Move(new Vector2(direction, 0), speed);
        transform.position = myRigidBody.position;

        //******Old Method******

        //Vector2 velocity = new Vector2(speed * direction, 0);

        //velocity = velocity + modifier;

        //myRigidBody.velocity = velocity;
    }

    public void Move(Vector2 direction, float speed)
    {
        myRigidBody.MovePosition(myRigidBody.position + direction * Time.deltaTime * speed);
    }

    public void MovementModifier(Vector2 mod)
    {
        modifier = mod;
    }

    protected bool DetectObs()
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(direction, 0);

        myBoxCollider2D.enabled = false;

        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);

        return false;
    }

}
