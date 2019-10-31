using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditscript : MonoBehaviour
{

    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y >= 26)
        {
            Application.Quit();
        }

        Vector3 newPosition = gameObject.transform.position;
        newPosition.y += speed * Time.deltaTime;
        gameObject.transform.position = newPosition;
    }
}
