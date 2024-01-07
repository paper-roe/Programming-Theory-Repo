using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameManager : MonoBehaviour
{
    public BattleState state;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform playerSpawn;
    [SerializeField] Transform enemySpawn;

    Unit playerUnit;
    Unit enemyUnit;

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
        enemyUnit = enemyGO.GetComponent<Unit>();
        enemyBattleInfo.DisplayBattleInfo(enemyUnit);
    }
}
