using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float fireballSpeed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.SendMessage("FireballHit", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
