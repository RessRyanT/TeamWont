using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float fireballSpeed;

    private Rigidbody2D myRigidBody;

    public Vector3 myVelocity;
    private void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();

        myVelocity = new Vector3(fireballSpeed, 0, 0);
    }

    private void Update()
    {
        myRigidBody.velocity = myVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.SendMessage("FireballHit", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

    public void SetLeft()
    {
        myVelocity = new Vector3(-fireballSpeed, 0, 0);
    }

}
