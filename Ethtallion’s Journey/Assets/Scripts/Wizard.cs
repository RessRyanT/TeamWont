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


    
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myRigidBody.AddForce(new Vector2(speed, 0));

        speedUp = 0.5f;
        maxSpeed = 2f;
        direction = 1f;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //When hit a wall, reduce speed and turn around
        if (myRigidBody.GetRelativePointVelocity(transform.position) == Vector2.zero)
        {
            speed = 0.5f;
            direction = -direction;
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

        //Move the walker
        myRigidBody.velocity = new Vector2(speed * direction, 0);
    }

}
