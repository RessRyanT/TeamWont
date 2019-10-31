using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityManager : MonoBehaviour
{
    public List<GameObject> stored;
    bool active;
    int countdown;
    static int CD_MAX = 30;
    public int timesCast;
    ParticleSystem particles;

    CircleCollider2D wizradius;
    private void Start()
    {
        timesCast =  0;
        countdown = CD_MAX;
        active = false;
        wizradius = gameObject.GetComponent<CircleCollider2D>();
        particles = GetComponent<ParticleSystem>();
        
    }

    private void Update()
    {
        if (active)
        {
            foreach (GameObject g in stored)
            {
                if (wizradius.IsTouching(g.GetComponent<Collider2D>()))
                {
                    g.SendMessage("OnZap", timesCast);
                }
            }
            countdown--;
        }
        if (countdown <= 0)
        {
            active = false;
            countdown = CD_MAX;
            particles.Stop();
        }
    }


    public void WhenCast()
    {
        if (!active)
        {
            active = true;
            timesCast++;
            particles.Play();
        }
    }

    


}
