using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player's Speed")]
    [SerializeField] protected float speed = 5f;

    [Header("Player's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;


    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Moving();
    }




    private void Reset()
    {
        LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        Rigidbody2D rb2d = transform.parent.Find("Model").gameObject.GetComponent<Rigidbody2D>();
        this.rb = rb2d;
    }

    protected virtual void Moving()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        this.rb.velocity = new Vector2 (xAxis * speed, yAxis * speed);
    }
}
