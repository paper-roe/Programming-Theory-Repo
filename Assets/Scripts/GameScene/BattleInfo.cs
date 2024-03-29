using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI unitNameText;
    [SerializeField] TextMeshProUGUI unitDamageText;
    [SerializeField] TextMeshProUGUI unitHealthText;

    public void DisplayBattleInfo(Unit unit)
    {
        unitNameText.text = unit.unitName;
        unitDamageText.text = "Base damage per hit: " + unit.damage;
        UpdateHealthText(unit.curHealth, unit.maxHealth);
    }

    public void UpdateHealthText(int curHealth, int maxHealth)
    {
        unitHealthText.text = "HP " + curHealth + "/" + maxHealth;
    }
}
