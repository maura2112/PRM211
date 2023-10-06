using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Action : MonoBehaviour, IEnemy
{
    [Header("Enemy's attribute")]
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float zigzagSpeed = 1f;
    [SerializeField] protected float zigzagDistance = 1f;
    [SerializeField] protected Vector3 startPosition;

    [Header("Enemy's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;

    private void Start()
    {
    }
    private void Reset()
    {
        this.LoadComponents();
    }

    private void Update()
    {
        this.Move();

    }

    protected virtual void LoadComponents()
    {
        this.rb = this.getModel().GetComponent<Rigidbody2D>();
        this.startPosition = this.getModel().transform.position;
    }

    protected virtual GameObject getModel()
    {
        return transform.parent.Find("Model").gameObject;
    }
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
            float newX = this.startPosition.x + Mathf.Sin(Time.time * speed) * zigzagDistance;
            float newY = this.startPosition.y - Time.time * zigzagSpeed;
            Vector3 newPosition = new Vector3(newX, newY, this.getModel().transform.position.z);
            this.getModel().transform.position = newPosition;
            Destroy(transform.parent.gameObject, 10f);
    }
}
