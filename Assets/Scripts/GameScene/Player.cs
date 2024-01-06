using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI playerDamageText;
    [SerializeField] TextMeshProUGUI playerNameText;
    public int health { get; private set; }
    private int damage;
    private string playerName;

    private void Start()
    {
        SetPlayerInfo();
        DisplayPlayerInfo();
    }

    private void SetPlayerInfo()
    {
        health = 100;
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
        playerHealthText.text = "HP " + health.ToString() + "/100";
        playerDamageText.text = "Damage: " + damage.ToString() + " per hit";
        playerNameText.text = playerName;
    }

    public void ReceiveDamage(int damageReceived)
    {
        health -= damageReceived;
        if (health <= 0)
        {
            health = 0;
            PlayerDead();
        }
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        playerHealthText.text = "HP " + health.ToString() + "/100";
    }

    private void PlayerDead()
    {
        Debug.Log("Player is dead");
    }
}
