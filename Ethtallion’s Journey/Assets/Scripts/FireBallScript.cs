﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float fireballSpeed;

    private Rigidbody2D myRigidBody;
    public float SetVelocity
    {
        set
        {
            myVelocity = new Vector3(value, 0, 0);
            myRigidBody.velocity = new Vector3(value, 0, 0);
            
        }
    }

    public Vector3 myVelocity;
    private void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();

        //myVelocity = new Vector3(fireballSpeed, 0, 0);
    }

    private void Update()
    {
        myRigidBody.velocity = myVelocity;
        if(myVelocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Destructable" || collision.gameObject.tag == "Fireball")
        {
            collision.collider.SendMessage("FireballHit", SendMessageOptions.DontRequireReceiver);
            // Debug.Log("Hit a wall or kirby");
        }
        else
        {
            // Debug.Log("Hit something else");
            Destroy(gameObject);
        }
        // Debug.Log("I'm colliding");
        // Destroy(gameObject);
    }

    public void SetLeft()
    {
        Debug.Log("SetLeft is run");
        myVelocity = new Vector3(-fireballSpeed, 0, 0);
    }


}
