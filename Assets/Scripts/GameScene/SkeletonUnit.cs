using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonUnit : Unit
{
    public float damageTakenMultiplier = 1.5f;

    private string m_unitName;
    public new string unitName
    {
        get { return m_unitName; }
        private set { }
    }

    private void Awake()
    {
        m_unitName = "Skeleton Army";
    }
}
