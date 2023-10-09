using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attribute : MonoBehaviour
{
    [Header("Enemy's attribute")]
    [SerializeField] protected float health;
    [SerializeField] protected float dmg;
    [SerializeField] protected float point;
    [SerializeField] protected float money;

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
