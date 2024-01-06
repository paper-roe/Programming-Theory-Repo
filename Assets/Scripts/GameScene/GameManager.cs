using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemyNameText;
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] TextMeshProUGUI fightButtonText;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform playerSpawn;
    [SerializeField] Transform enemySpawn;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleInfo playerInfo;
    public BattleInfo enemyInfo;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = enemyGO.GetComponent<Unit>();

        enemyNameText.text = enemyUnit.unitName;
        playerNameText.text = playerUnit.unitName;

        playerInfo.DisplayBattleInfo(playerUnit);
        enemyInfo.DisplayBattleInfo(enemyUnit);
    }
}
