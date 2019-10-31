using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySwitch : MonoBehaviour
{

    public GameObject target;
    int timezap;

    // Start is called before the first frame update
    void Start()
    {
        timezap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnZap(int s_timezap)
    {
        //checks if this object has been zapped by this specific spell before
        if(s_timezap != timezap)
        {
            //if not, sets id of timezap
            timezap = s_timezap;

            //toggles between blue and white, corresponding to on/off
            if (target.activeSelf)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }


            //then either removes or reactivates the target object
            target.SetActive(!target.activeSelf);
        }
        
    }
}
