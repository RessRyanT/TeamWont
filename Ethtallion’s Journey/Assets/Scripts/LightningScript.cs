using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    Vector3 speed = new Vector3(0.5f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed + gameObject.transform.position;
        gameObject.transform.position = speed;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(true /*something to describe a solid object*/)
        {
            if(false /*this object is effected by a lightningbolt&*/)
            {
                //stuff goes here
            }


            Object.Destroy(gameObject);
        }
        
        
    }
}
