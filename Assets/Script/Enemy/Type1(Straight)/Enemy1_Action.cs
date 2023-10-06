using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Action : MonoBehaviour, IEnemy
{
    [Header("Enemy's attribute")]
    [SerializeField] protected float speed = 3f;

    [Header("Enemy's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;

    private void Start()
    {
        this.Move();
    }
    private void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        this.rb = transform.parent.Find("Model").GetComponent<Rigidbody2D>();
    }
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        this.rb.velocity = new Vector2(0f, -speed);
        Destroy(transform.parent.gameObject, 10f);
    }
}
