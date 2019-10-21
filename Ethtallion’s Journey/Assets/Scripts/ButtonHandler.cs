using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public GameObject InputManagerObject;

    public void SendNumber()
    {
        if(gameObject.name == "YellowButton")
        {
            InputManagerObject.GetComponent<InputManager>().TakeInput(101);
        }
        else if (gameObject.name == "RedButton")
        {
            InputManagerObject.GetComponent<InputManager>().TakeInput(113);
        }
        else if (gameObject.name == "BlueButton")
        {
            InputManagerObject.GetComponent<InputManager>().TakeInput(119);
        }
        else
        {
            InputManagerObject.GetComponent<InputManager>().TakeInput(1);
        }

        // InputManagerObject.GetComponent<InputManager>().TakeInput(1);
    }
}
