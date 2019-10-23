using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // variables
    public uint totalKeyValue;

    public GameObject SpellManagerObject;

    // enums for spells
    enum SpellName
    {
        Fireball = 226, // red and red
        Gust = 232, // red and blue
        BlockShift = 214, // red and yellow
        Shock = 220, // blue and yellow
        InverseG = 333 // red blue and yellow
    }

    // q is red
    // w is blue
    // e is yellow

    // Start is called before the first frame update
    void Start()
    {
        totalKeyValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.Space))
        // {
        KBinput();
        // }

        if (totalKeyValue >= 202)
        {
            SpellSwitch((SpellName)totalKeyValue);
            ResetKeyVal();
        }
    }

    public void TransferSpell(int spellInput)
    {
        SpellManagerObject.GetComponent<SpellManagerScript>().CastSpell(spellInput);
        Debug.Log("Spell " + spellInput + " sent to Spell Manager");
    }

    public void ScreenButtonInput(uint input)
    {
        totalKeyValue += input;
        Debug.Log(totalKeyValue);

    }

    public void KBinput()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            totalKeyValue += (int)KeyCode.Q; // 113
            Debug.Log(totalKeyValue);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            totalKeyValue += (int)KeyCode.W; // 119
            Debug.Log(totalKeyValue);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            totalKeyValue += (int)KeyCode.E; // 101
            Debug.Log(totalKeyValue);
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log(totalKeyValue);
        }
    }

    void ResetKeyVal()
    {
        totalKeyValue = 0;
    }

    void SpellSwitch(SpellName spellCast)
    {
        ResetKeyVal();
        switch (spellCast)
        {
            case SpellName.Fireball:
                TransferSpell((int)SpellName.Fireball);
                Debug.Log("Fireball");
                ResetKeyVal();
                break;
            case SpellName.Gust:
                TransferSpell((int)SpellName.Gust);
                Debug.Log("Gust");
                ResetKeyVal();
                break;
            case SpellName.BlockShift:
                TransferSpell((int)SpellName.BlockShift);
                Debug.Log("BlockShift");
                ResetKeyVal();
                break;
            case SpellName.Shock:
                TransferSpell((int)SpellName.Shock);
                Debug.Log("Shock");
                ResetKeyVal();
                break;
            case SpellName.InverseG:
                TransferSpell((int)SpellName.InverseG);
                Debug.Log("InverseG");
                ResetKeyVal();
                break;
            default:
                // fail case
                Debug.Log("Fail");
                ResetKeyVal();
                break;
        }
    }
}
