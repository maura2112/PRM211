using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Action : MonoBehaviour, IEnemy
{
    [Header("Enemy's attribute")]
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float zigzagSpeed = 1f;
    [SerializeField] protected float zigzagDistance;
    [SerializeField] protected Vector3 startPosition;
    [SerializeField] protected float startTime;

    [Header("Enemy's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;

    private void Start()
    {
        this.speed = Random.Range(1.5f, 3f);
        this.zigzagSpeed = Random.Range(1f, 2f);
        this.zigzagDistance = Random.Range(0.5f, 1f);
        startTime = Time.time;
        this.startPosition = this.getModel().transform.position;
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
            float timeElapsed = Time.time - startTime;
            float newX = this.startPosition.x + Mathf.Sin(Time.time * speed) * zigzagDistance;
            float newY = this.startPosition.y - timeElapsed * zigzagSpeed;
            Vector3 newPosition = new Vector3(newX, newY, this.getModel().transform.position.z);
            this.getModel().transform.position = newPosition;
            Destroy(transform.parent.gameObject, 12f);
    }
}
