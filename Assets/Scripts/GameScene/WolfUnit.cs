using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfUnit : Unit
{
    [SerializeField] GameObject hyperArmor;
    Vector3 offScreen = new Vector3(0, 500);

    private void Start()
    {
        hyperArmor = GameObject.Find("Wolf Hyper Armor");
    }

    IEnumerator DisplayHyperArmorMessage()
    {
        hyperArmor.transform.position = Vector3.zero;
        yield return new WaitForSeconds(3f);
        hyperArmor.transform.position = offScreen;
    }

    public bool AttemptHyperArmor()
    {
        int hyperArmorNumber = 3;
        int hyperArmorRoll = 1 + (Mathf.RoundToInt(Random.Range(0, hyperArmorNumber)));

        if (hyperArmorRoll == hyperArmorNumber)
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
