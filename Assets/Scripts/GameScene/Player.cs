using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI playerDamageText;
    [SerializeField] TextMeshProUGUI playerNameText;
    private int hitPoints;
    private int damage;
    private string playerName;

    private void Start()
    {
        SetPlayerInfo();
        DisplayPlayerInfo();
    }

    private void SetPlayerInfo()
    {
        hitPoints = 100;
        damage = 5;
        if (TitleScreenManager.playerName == null)
        {
            playerName = "???";
        }
        else
        {
            playerName = TitleScreenManager.playerName;
        }        
    }

    private void DisplayPlayerInfo()
    {
        playerHealthText.text = "HP " + hitPoints.ToString() + "/100";
        playerDamageText.text = "Damage: " + damage.ToString() + " per hit";
        playerNameText.text = playerName;
    }
}
