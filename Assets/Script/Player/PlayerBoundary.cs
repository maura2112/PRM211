using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    [Header("ScreenSize")]
    [SerializeField] protected float minX;
    [SerializeField] protected float maxX;
    [SerializeField] protected float minY;
    [SerializeField] protected float maxY;

    [Header("Boundary's Size")]
    [SerializeField] protected float boundarySize = 0.5f;

    [Header("Player's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;

    private void Start()
    {
        this.Boundary();
    }

    private void Update()
    {
        this.PlayerBound();
    }

    private void Reset()
    {
        this.Boundary();
        this.LoadComponents();
    }
    protected virtual Vector3 ScreenSize()
    {
        Vector3 screenSize = new Vector3(Screen.width, Screen.height, 0f);
        return screenSize;
    }
    protected virtual void Boundary()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(ScreenSize());
        this.minX = -bounds.x + boundarySize;
        this.maxX = bounds.x - boundarySize;
        this.minY = -bounds.y + boundarySize;
        this.maxY = bounds.y - boundarySize;
    }

    protected virtual void LoadComponents()
    {
        Rigidbody2D rb2d = transform.parent.Find("Model").gameObject.GetComponent<Rigidbody2D>();
        this.rb = rb2d;
    }
    protected virtual void PlayerBound()
    {
        GameObject model = transform.parent.Find("Model").gameObject;

        Vector3 temp = model.transform.position;
        if (temp.x < minX)
        {
            temp.x = minX;
        }
        else if (temp.x > maxX)
        {
            temp.x = maxX;
        }
        if (temp.y < minY)
        {
            temp.y = minY;
        }
        else if (temp.y > maxY)
        {
            temp.y = maxY;
        }
        model.transform.position = temp;

    }

}
