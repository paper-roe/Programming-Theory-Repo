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
    [Header("Unit Prefabs")]
    [SerializeField] private PlayerUnit playerPrefab;
    [SerializeField] private List<Unit> enemyPrefabs;

    [Header("Spawn Points")]
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private Transform enemySpawn;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI fightButtonText;
    [SerializeField] private BattleInfo playerBattleInfo;
    [SerializeField] private BattleInfo enemyBattleInfo;

    [Header("Batte State")]
    public BattleState state;

    private PlayerUnit playerUnit;
    private Unit enemyUnit;

    private void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    private void SetupBattle()
    {
        playerUnit = Instantiate(playerPrefab, playerSpawn);
        playerBattleInfo.DisplayBattleInfo(playerUnit);

        ChooseRandomEnemy();

        state = BattleState.PLAYERTURN;
        SetFightButtonText(playerUnit, enemyUnit);
    }

    private void ChooseRandomEnemy()
    {
        Unit randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        enemyUnit = Instantiate(randomEnemy, enemySpawn);
        enemyBattleInfo.DisplayBattleInfo(enemyUnit);
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

    private void PlayerTurn()
    {
        SetFightButtonText(playerUnit, enemyUnit);

        state = BattleState.ENEMYTURN;

        int damage = CalculateAttackDamage(playerUnit, enemyUnit);
        bool isDead = enemyUnit.TakeDamage(damage);
        UpdateEnemyHealthText();

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            fightButtonText.text = enemyUnit.unitName + " attacking for " + enemyUnit.damage + " damage";
        }
    }

    void EnemyTurn()
    {
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerBattleInfo.UpdateHealthText(playerUnit.curHealth, playerUnit.maxHealth);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            SetFightButtonText(playerUnit, enemyUnit);
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

    private int CalculateAttackDamage(Unit attackingUnit, Unit defendingUnit)
    {
        return Mathf.RoundToInt(attackingUnit.damage * defendingUnit.damageTakenMultiplier);
    }

    void UpdateEnemyHealthText()
    {
        enemyBattleInfo.UpdateHealthText(enemyUnit.curHealth, enemyUnit.maxHealth);
    }

    private void SetFightButtonText(Unit attackingUnit, Unit defendingUnit)
    {
        int damage = CalculateAttackDamage(attackingUnit, defendingUnit);
        fightButtonText.text = "Attack " + defendingUnit.unitName + " for " + damage + " damge";
    }
}
