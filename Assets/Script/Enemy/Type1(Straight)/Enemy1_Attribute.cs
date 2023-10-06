using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Attribute : Enemy_Attribute
{

    private void Start()
    {
        
    }

    private void Reset()
    {
        this.LoadAttributes();
    }

    protected virtual void LoadAttributes()
    {
        this.health = 1f;
        this.dmg = 1f;

    }

}
