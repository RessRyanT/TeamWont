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
    SpriteRenderer mySpriteRenderer;

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

}
