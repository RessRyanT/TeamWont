using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public int BUTTON_KEY_VALUE;
    public GameObject InputManagerObject;

    public void SendNumber()
    {
        InputManagerObject.GetComponent<InputManager>().ScreenButtonInput(BUTTON_KEY_VALUE);
    }
}
