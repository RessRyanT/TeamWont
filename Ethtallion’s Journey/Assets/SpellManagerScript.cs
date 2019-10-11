using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
             
                break;
            case 232: // Gust
                
                Debug.Log("Gust Cast");
                
                break;
            case 214: // BlockShift
               
                Debug.Log("BlockShift Cast");
                
                break;
            case 220: // Shock
                
                Debug.Log("Shock Cast");
      
                break;
            case 333: // InverseG
              
                Debug.Log("InverseG Cast");
           
                break;
            default:
                // fail case
                Debug.Log("Fail");
                
                break;
        }
    }
}
