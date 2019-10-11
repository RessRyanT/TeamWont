using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public GameObject InputManagerObject;

    public void SendNumber()
    {
        InputManagerObject.GetComponent<InputManager>().TakeInput(1);
    }
}
