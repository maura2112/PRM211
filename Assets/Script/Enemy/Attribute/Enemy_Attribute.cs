using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void Update()
    {
        this.LoadTransform();
    }

    private void Reset()
    {
        this.LoadAttributes();
    }

    public virtual void LoseHP(float amount)
    {
        this.health -= amount;
        if(this.health <= 0)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
    

    protected virtual void LoadAttributes()
    {
        this.health = 1f;
        this.dmg = 1f;
        this.LoadTransform();

        PolygonCollider2D modelCollider = this.transform.parent.Find("Model").GetComponent<PolygonCollider2D>();
        PolygonCollider2D attributeCollider = this.gameObject.GetComponent<PolygonCollider2D>();
        attributeCollider.pathCount = modelCollider.pathCount;
        for (int i = 0; i < modelCollider.pathCount; i++)
        {
            attributeCollider.SetPath(i, modelCollider.GetPath(i));
        }

    }

    protected virtual void LoadTransform()
    {
        Transform modelTransform = this.transform.parent.Find("Model").GetComponent<Transform>();
        this.transform.position = modelTransform.position;
        this.transform.rotation = modelTransform.rotation;
        this.transform.localScale = modelTransform.localScale;
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.AddScore(this.point);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth.Instance.LoseHP(this.dmg);
        }
    }

}
