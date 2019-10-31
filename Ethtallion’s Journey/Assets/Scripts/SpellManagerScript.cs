using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpellManagerScript : MonoBehaviour
{

    int effectRadius;
    GameObject wizardRef;
    Wizard wizardScriptRef;
    Rigidbody2D m_RigidBody2D;

    public AudioClip fireAudio;
    public AudioClip gustAudio;
    public AudioClip blinkAudio;
    public AudioClip zapAudio;

    public AudioSource audioSource;

    public GameObject lightning;
    public GameObject gust;
    public GameObject fireball;
    private Vector3 fbxOffset = new Vector3(1.5f, 0, 0);
    private Vector3 fbyOffset = new Vector3(0, 0.5f, 0);


    List<Collider2D> colliders;

    // Start is called before the first frame update
    void Start()
    {
        wizardScriptRef = GameObject.FindObjectOfType<Wizard>();
        wizardRef = wizardScriptRef.gameObject;
        m_RigidBody2D = wizardRef.GetComponent<Rigidbody2D>();

        colliders = new List<Collider2D>(GameObject.FindObjectsOfType<Collider2D>());

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
        Fireball = 226, // red and red
        Gust = 232, // red and blue
        BlockShift = 214, // red and yellow
        Shock = 220, // yellow and yellow
        InverseG = 333 // red blue and yellow
    */


    public void CastSpell(int spellID)
    {
        Debug.Log("Spell Manager casting spell " + spellID);
        switch (spellID)
        {
            case 226: // Fireball
                Debug.Log("Fireball Cast");
                GameObject instFireball = Instantiate(fireball, this.transform.position+(gameObject.GetComponentInParent<Wizard>().direction*fbxOffset+fbyOffset ), Quaternion.identity);
                //instFireball.transform.position = new Vector3(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
                instFireball.GetComponent<FireBallScript>().SetVelocity = gameObject.GetComponentInParent<Wizard>().direction * 2;

                audioSource.clip = fireAudio;
                audioSource.Play();

                /*f (gameObject.GetComponentInParent<Wizard>().direction < 0)
                {
                    Debug.Log("Shold fire backwards");
                    instFireball.GetComponent<SpriteRenderer>().flipX = true;
                }*/
                
                break;
            case 232: // Gust
                
                Debug.Log("Gust Cast");

                audioSource.clip = gustAudio;
                audioSource.Play();

                //Vector3 force = new Vector3(0, 100, 0);
                //m_RigidBody2D.AddForce(force, ForceMode2D.Impulse);
                Wizard wizard = Wizard.GetInstance();
                wizard.isJumping = true;
                
                break;
            case 214: // BlockShift
               
                Debug.Log("BlockShift Cast");
                
                break;
            case 202: // Shock

                audioSource.clip = zapAudio;
                audioSource.Play();

                Debug.Log("Shock Cast");
                //GameObject instLightning = Instantiate(lightning, wizardRef.transform.position, Quaternion.identity);
                GetComponentInChildren<ElectricityManager>().WhenCast();

                break;
            case 333: // InverseG
              
                Debug.Log("InverseG Cast");
                m_RigidBody2D.gravityScale *= -1;


                break;

            case 220: //I dont know what the color code would be but
                      //Blink

                audioSource.clip = blinkAudio;
                audioSource.Play();

                Vector2 newPosition = new Vector2(wizardRef.transform.position.x, wizardRef.transform.position.y);
                Debug.Log(newPosition);
                newPosition += new Vector2(5.0f * wizardScriptRef.direction, 0.2f);

                Debug.Log(newPosition);

                bool valid = true;
                
                foreach(Collider2D c in colliders)
                {

                    if (c.OverlapPoint(newPosition)) valid = false;
                }

                if (valid)
                {
                    Vector3 tempvec = new Vector3(newPosition.x, newPosition.y, 2.0f);
                    wizardRef.transform.position = tempvec;

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
