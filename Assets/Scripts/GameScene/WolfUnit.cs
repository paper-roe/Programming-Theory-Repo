using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfUnit : Unit
{
    private GameObject hyperArmorMessage;
    private Vector3 offScreen = new Vector3(-5f, 2);
    private Vector3 onScreen = new Vector3(-5f, -6f);

    private void Awake()
    {
        hyperArmorMessage = GameObject.Find("Wolf Hyper Armor Message");
        hyperArmorMessage.transform.localPosition = offScreen;
    }

    IEnumerator DisplayHyperArmorMessage()
    {
        hyperArmorMessage.transform.localPosition = onScreen;
        yield return new WaitForSeconds(3f);
        hyperArmorMessage.transform.localPosition = offScreen;
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
