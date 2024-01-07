using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfUnit : Unit
{
    GameObject hyperArmor;
    Vector3 offScreen = new Vector3(0, 500);

    private string m_unitName;
    public new string unitName
    {
        get { return m_unitName; }
        private set { } 
    }

    private void Awake()
    {
        m_unitName = "Wolf";
        hyperArmor = GameObject.Find("Wolf Hyper Armor Message");
    }

    IEnumerator DisplayHyperArmorMessage()
    {
        hyperArmor.transform.position = Vector3.zero;
        yield return new WaitForSeconds(3f);
        hyperArmor.transform.position = offScreen;
    }

    public bool AttemptHyperArmor()
    {
        int hyperArmorActivateNumber = 3;
        int hyperArmorRoll = 1 + (Mathf.RoundToInt(Random.Range(0, hyperArmorActivateNumber)));

        if (hyperArmorRoll == hyperArmorActivateNumber)
        {
            StartCoroutine(DisplayHyperArmorMessage());
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool TakeDamage(int dmg)
    {
        int hyperArmorReduction = 2;

        if (AttemptHyperArmor())
        {
            curHealth -= Mathf.RoundToInt(dmg / hyperArmorReduction);
        }
        else
        {
            curHealth -= dmg;
        }        

        if (curHealth <= 0)
        {
            curHealth = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
