using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    float speed;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        speed = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        transform.position += transform.right * speed * Time.deltaTime;


        
    }


    
}
