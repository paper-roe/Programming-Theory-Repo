using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    private void Awake()
    {
        if (string.IsNullOrEmpty(TitleScreenManager.playerName))
        {
            unitName = "???";
        }
        else
        {
            unitName = TitleScreenManager.playerName;
        }        
    }
}
