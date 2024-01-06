using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHealth;
    public int curHealth;

    protected void Start()
    {
        maxHealth = 100;
        curHealth = 100;
        damage = 15;

        Debug.Log(gameObject.name);
        if (gameObject.name == "Player(Clone)")
        {
            unitName = TitleScreenManager.playerName;
        }
    }
}
