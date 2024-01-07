using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    private string m_unitName;
    public new string unitName
    {
        get { return m_unitName; }
        private set { }
    }

    private void Awake()
    {
        if (TitleScreenManager.playerName == "" || TitleScreenManager.playerName == null)
        {
            m_unitName = "???";
        }
        else
        {
            m_unitName = TitleScreenManager.playerName;
        }        
    }
}
