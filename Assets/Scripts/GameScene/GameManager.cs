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
    [SerializeField] GameObject enemyWolfPrefab;
    [SerializeField] GameObject enemySkeletoPrefab;

    [SerializeField] Transform playerSpawn;
    [SerializeField] Transform enemySpawn;

    PlayerUnit playerUnit;
    WolfUnit enemyWolfUnit;
    SkeletonUnit enemySkeletonUnit;

    [SerializeField] BattleInfo playerBattleInfo;
    [SerializeField] BattleInfo enemyBattleInfo;

    string enemyUnitName;
    // These variables used below to display their values on the Fight Button. Workaround for lack of knowledge.
    int enemyUnitDamage; // This is bad because damage won't update if I add dmg mods later..
    int playerDamage; // This is bad because damage won't update if I add dmg mods later..

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerGO.GetComponent<PlayerUnit>();
        playerBattleInfo.DisplayBattleInfo(playerUnit);

        ChooseRandomEnemy();

        state = BattleState.PLAYERTURN;
        fightButtonText.text = "Attack " + enemyUnitName + " for " + playerDamage + " damage";
    }

    // I don't know proper way to do it via list/array
    // (can make the list, but unsure about code outside of this method)
    void ChooseRandomEnemy()
    {
        int randomEnemy = Random.Range(0, 2);

        if (randomEnemy == 0)
        {
            GameObject enemyGO = Instantiate(enemyWolfPrefab, enemySpawn);
            enemyWolfUnit = enemyGO.GetComponent<WolfUnit>();
            enemyBattleInfo.DisplayBattleInfo(enemyWolfUnit);
            enemyUnitName = enemyWolfUnit.unitName;
            enemyUnitDamage = enemyWolfUnit.damage;
            playerDamage = playerUnit.damage;
        }
        else
        {
            GameObject enemyGO = Instantiate(enemySkeletoPrefab, enemySpawn);
            enemySkeletonUnit = enemyGO.GetComponent<SkeletonUnit>();
            enemyBattleInfo.DisplayBattleInfo(enemySkeletonUnit);
            
            enemyUnitName = enemySkeletonUnit.unitName;
            enemyUnitDamage = enemySkeletonUnit.damage;
            playerDamage = Mathf.RoundToInt(playerUnit.damage * enemySkeletonUnit.damageTakenMultiplier);
        }        
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
        fightButtonText.text = "Attack " + enemyUnitName + " for " + playerDamage + " damage";

        state = BattleState.ENEMYTURN;
        bool isDead = EnemyTakeDamage();
        UpdateEnemyHealth();

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            fightButtonText.text = enemyUnitName + " attacking for " + enemyUnitDamage + " damage";
        }
    }

    void EnemyTurn()
    {
        bool isDead = playerUnit.TakeDamage(enemyUnitDamage);
        playerBattleInfo.UpdateHealth(playerUnit.curHealth, playerUnit.maxHealth);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            fightButtonText.text = "Attack " + enemyUnitName + " for " + playerDamage + " damage";
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

    bool EnemyTakeDamage()
    {
        if (enemyUnitName == "Wolf")
        {
            return enemyWolfUnit.TakeDamage(playerDamage);
        }
        else
        {
            return enemySkeletonUnit.TakeDamage(playerDamage);
        }
    }

    void UpdateEnemyHealth()
    {
        if (enemyUnitName == "Wolf")
        {
            enemyBattleInfo.UpdateHealth(enemyWolfUnit.curHealth, enemyWolfUnit.maxHealth);
        }
        else
        {
            enemyBattleInfo.UpdateHealth(enemySkeletonUnit.curHealth, enemySkeletonUnit.maxHealth);
        }
    }
}
