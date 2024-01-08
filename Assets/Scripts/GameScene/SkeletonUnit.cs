using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkeletonUnit : Unit
{
    private GameManager gameManager;
    private TextMeshProUGUI fightButtonText;

    private GameObject brittleBonesMessage;
    private Vector3 brittleBonesMessageOnScreen = new Vector3(-4f, -11.5f);

    int tripleStrikeAttempts;

    private void Awake()
    {
        tripleStrikeAttempts = 2;

        fightButtonText = GameObject.Find("Fight Button Text").GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        brittleBonesMessage = GameObject.Find("Skeleton Brittle Bones Message");
        brittleBonesMessage.transform.localPosition = brittleBonesMessageOnScreen;
    }

    private void Update()
    {
        if (gameManager.state == BattleState.ENEMYTURN && tripleStrikeAttempts < 2)
        {
            tripleStrikeAttempts += 1;
            int tripleStrikeMultiplier = 3;
            int tripletrikeActivateNumber = 4;
            int tripleStrikeRoll = 1 + (Mathf.RoundToInt(Random.Range(0, tripletrikeActivateNumber)));

            if (tripleStrikeRoll == tripletrikeActivateNumber)
            {
                tripleStrikeAttempts = 2;
                damage *= tripleStrikeMultiplier;
                fightButtonText.text = unitName + " Triple Striking for " + damage + " damage";
            }
        }
        if (gameManager.state != BattleState.ENEMYTURN)
        {
            damage = 15;
            tripleStrikeAttempts = 0;
        }
    }
}
