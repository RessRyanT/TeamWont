using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(0);
        }

        Vector3 newPosition = gameObject.transform.position;
        newPosition.y += speed * Time.deltaTime;
        gameObject.transform.position = newPosition;
    }
}
