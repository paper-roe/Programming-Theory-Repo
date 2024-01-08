using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public float damageTakenMultiplier;
    public int damage;
    public int maxHealth;
    public int curHealth;

    public virtual bool TakeDamage(int dmg)
    {
        curHealth -= dmg;

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
