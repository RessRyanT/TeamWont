using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpellManagerScript : MonoBehaviour
{

    int effectRadius;
    GameObject wizardRef;
    Wizard wizardScriptRef;
    Rigidbody2D m_RigidBody2D;
    

    

    public GameObject lightning;
    public GameObject gust;
    public GameObject fireball;


    List<Collider2D> colliders;

    // Start is called before the first frame update
    void Start()
    {
        wizardScriptRef = GameObject.FindObjectOfType<Wizard>();
        wizardRef = wizardScriptRef.gameObject;
        m_RigidBody2D = wizardRef.GetComponent<Rigidbody2D>();

        colliders = new List<Collider2D>(GameObject.FindObjectsOfType<Collider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
        Fireball = 226, // red and red
        Gust = 232, // red and blue
        BlockShift = 214, // red and yellow
        Shock = 220, // blue and yellow
        InverseG = 333 // red blue and yellow
    */

    public void CastSpell(int spellID)
    {
        Debug.Log("Spell Manager casting spell " + spellID);
        switch (spellID)
        {
            case 226: // Fireball
              
                Debug.Log("Fireball Cast");
                GameObject instFireball = Instantiate(fireball, this.transform.position,Quaternion.identity);
                if (this.GetComponentInParent<Wizard>().direction < 0)
                {
                    instFireball.GetComponent<FireBallScript>().SetLeft();
                }
                
                break;
            case 232: // Gust
                
                Debug.Log("Gust Cast");

                //Vector3 force = new Vector3(0, 100, 0);
                //m_RigidBody2D.AddForce(force, ForceMode2D.Impulse);
                Wizard wizard = Wizard.GetInstance();
                wizard.isJumping = true;
                

                
                break;
            case 214: // BlockShift
               
                Debug.Log("BlockShift Cast");
                
                break;
            case 220: // Shock
                
                Debug.Log("Shock Cast");
                //GameObject instLightning = Instantiate(lightning, wizardRef.transform.position, Quaternion.identity);
                GetComponentInChildren<ElectricityManager>().WhenCast();

                break;
            case 333: // InverseG
              
                Debug.Log("InverseG Cast");
                m_RigidBody2D.gravityScale *= -1;


                break;

            case 111: //I dont know what the color code would be but
                //Blink

                Vector3 newPosition = wizardRef.transform.position;
                newPosition.x += 1;

                bool valid = true;
                
                foreach(Collider2D c in colliders)
                {
                    if (c.OverlapPoint(newPosition)) valid = false;
                }

                if (valid)
                {
                    wizardRef.transform.position = newPosition;
                }
                else
                {
                    Debug.Log("Invalid Tele");
                }
                

               

                 
                

                break;
            default:
                // fail case
                Debug.Log("Fail");
                
                break;
        }
    }
}
