using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unitNameText;
    [SerializeField] TextMeshProUGUI unitDamageText;
    [SerializeField] TextMeshProUGUI unitHealthText;

    public void DisplayBattleInfo<T>(T unit) where T : Unit
    {
        unitNameText.text = GetComponentInChildren<T>().unitName;
        unitDamageText.text = "Damage per hit: " + unit.damage;
        UpdateHealth(unit.curHealth, unit.maxHealth);
    }

    public void UpdateHealth(int curHealth, int maxHealth)
    {
        unitHealthText.text = "HP " + curHealth + "/" + maxHealth;
    }
}
