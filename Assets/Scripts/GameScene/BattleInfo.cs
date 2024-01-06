using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI damageText;

    public void DisplayBattleInfo(Unit unit)
    {
        healthText.text = "HP " + unit.curHealth.ToString() + "/100";
        damageText.text = "Damage: " + unit.damage.ToString() + " per hit";
    }
}
