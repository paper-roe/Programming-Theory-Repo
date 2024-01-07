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
        unitDamageText.text = "Damage per hit: " + unit.damage;
        unitHealthText.text = "HP " + unit.curHealth + "/" + unit.maxHealth;
    }
}
