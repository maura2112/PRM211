using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_Attribute : Enemy_Attribute
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
        this.health = 10f;
        this.dmg = 2f;
    }
}
