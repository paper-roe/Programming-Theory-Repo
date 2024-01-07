using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameManager : MonoBehaviour
{
    public BattleState state;

    [SerializeField] TextMeshProUGUI fightButtonText;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform playerSpawn;
    [SerializeField] Transform enemySpawn;

    Unit playerUnit;
    WolfUnit enemyWolfUnit;

    [SerializeField] BattleInfo playerBattleInfo;
    [SerializeField] BattleInfo enemyBattleInfo;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerGO.GetComponent<Unit>();
        playerBattleInfo.DisplayBattleInfo(playerUnit);

        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyWolfUnit = enemyGO.GetComponent<WolfUnit>();
        enemyBattleInfo.DisplayBattleInfo(enemyWolfUnit);

        state = BattleState.PLAYERTURN;
        fightButtonText.text = "Attack enemy for " + playerUnit.damage + " damage";
    }

    public void ProgressFight()
    {
        if (state == BattleState.PLAYERTURN)
        {
            PlayerTurn();
        }
        else if (state == BattleState.ENEMYTURN)
        {
            EnemyTurn();
        }
        else if (state == BattleState.WON || state == BattleState.LOST)
        {
            SceneManager.LoadScene(1);
        }
    }

    void PlayerTurn()
    {
        fightButtonText.text = "Attack enemy for " + playerUnit.damage + " damage";

        state = BattleState.ENEMYTURN;
        bool isDead = enemyWolfUnit.TakeDamage(playerUnit.damage);
        enemyBattleInfo.UpdateHealth(enemyWolfUnit.curHealth, enemyWolfUnit.maxHealth);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            fightButtonText.text = enemyWolfUnit.unitName + " attacking for " + enemyWolfUnit.damage + " damage";
        }
    }

    void EnemyTurn()
    {
        bool isDead = playerUnit.TakeDamage(enemyWolfUnit.damage);
        playerBattleInfo.UpdateHealth(playerUnit.curHealth, playerUnit.maxHealth);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            fightButtonText.text = "Attack " + enemyWolfUnit.unitName + " for " + playerUnit.damage + " damage";
        }
    }

    private void EndBattle()
    {
        if (state == BattleState.WON)
        {
            fightButtonText.text = "You won :) \nReset Game";
        }
        else if (state == BattleState.LOST)
        {
            fightButtonText.text = "You lost >:(  \nReset Game";
        }
    }
}
