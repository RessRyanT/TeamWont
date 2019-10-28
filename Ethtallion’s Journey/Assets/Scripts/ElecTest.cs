using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTest : MonoBehaviour
{
    int lastcast;
    void Start()
    {
        lastcast = -1;
    }

    void OnZap(int timescast)
    {
        if (timescast != lastcast)
        {
            lastcast = timescast;
            gameObject.SetActive(false);
        }
    }
}
