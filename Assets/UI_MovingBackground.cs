using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_MovingBackground : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] protected float speed = 300f;
    [SerializeField] protected Vector3 startPoint;

    [Header("Screen Y Size")]
    [SerializeField] protected float ScreenYSize;

    private void Reset()
    {
        this.startPoint = this.transform.position;
        this.ScreenYSize = Screen.height * 4;
    }
    private void Update()
    {
        this.Scrolling();
    }
    protected virtual void Scrolling()
    {
        this.transform.Translate(0, speed * Time.deltaTime, 0);
        if (Vector3.Distance(this.startPoint, this.transform.position) > this.ScreenYSize)
        {
            this.transform.position = this.startPoint;
        }
    }


}
