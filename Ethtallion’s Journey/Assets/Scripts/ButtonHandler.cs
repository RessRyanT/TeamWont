using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public uint BUTTON_KEY_VALUE;
    public GameObject InputManagerObject;
    public int remainingComponents;

    public void SendNumber()
    {
        if (remainingComponents > 0)
        {
            InputManagerObject.GetComponent<InputManager>().ScreenButtonInput(BUTTON_KEY_VALUE);
            remainingComponents--;
        }
        // gameObject.GetComponent<Text>().text = remainingComponents.ToString();
    }
}
