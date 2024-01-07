using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unitNameText;
    [SerializeField] TextMeshProUGUI unitDamageText;
    [SerializeField] TextMeshProUGUI unitHealthText;

    // I WANT THIS TO WORKKKKK
    // gets pissed off with the name. As is = "Object reference not set" error
    // without "GetComponent.." it wants to return the parent (Unit.cs) name value -_-
    /*    public void DisplayBattleInfo<T>(T unit) where T : Unit
        {
            unitNameText.text = GetComponentInChildren<T>().unitName;
            unitDamageText.text = "Damage per hit: " + unit.damage;
            UpdateHealth(unit.curHealth, unit.maxHealth);
        }*/

    public void DisplayBattleInfo(PlayerUnit unit)
    {
        unitNameText.text = unit.unitName;
        unitDamageText.text = "Damage per hit: " + unit.damage;
        UpdateHealth(unit.curHealth, unit.maxHealth);
    }

    public void DisplayBattleInfo(WolfUnit unit)
    {
        unitNameText.text = unit.unitName;
        unitDamageText.text = "Damage per hit: " + unit.damage;
        UpdateHealth(unit.curHealth, unit.maxHealth);
    }

    public void DisplayBattleInfo(SkeletonUnit unit)
    {
        unitNameText.text = unit.unitName;
        unitDamageText.text = "Damage per hit: " + unit.damage;
        UpdateHealth(unit.curHealth, unit.maxHealth);
    }

    public void UpdateHealth(int curHealth, int maxHealth)
    {
        unitHealthText.text = "HP " + curHealth + "/" + maxHealth;
    }
}
