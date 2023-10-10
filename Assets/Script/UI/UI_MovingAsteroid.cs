using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MovingAsteroid : MonoBehaviour
{
    [Header("Circle")]
    [SerializeField] protected float radius = 100f;
    [SerializeField] protected float speed = 0.5f;

    [Header("Position")]
    [SerializeField] protected Vector2 basestartpoint;
    [SerializeField] protected Vector2 destination;
    [SerializeField] protected Vector2 start;
    [SerializeField] protected float progress = 0.0f;

    [Header("Offset")]
    [SerializeField] protected float rotOffset = 180f;
    [SerializeField] protected float RotationSpeed = 3f;

    void Start()
    {
        PickNewRandomDestination();
    }

    private void Reset()
    {
        this.start = transform.localPosition;
        this.basestartpoint = transform.localPosition;
        this.progress = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        this.Flying();
    }

    protected virtual void PickNewRandomDestination()
    {
        this.destination = Random.insideUnitCircle * this.radius + this.basestartpoint;
    }

    private void RotateGameObject(Vector2 destination, float RotationSpeed, float offset)
    {
        Vector3 target = destination;
        Vector3 dir = target - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    }

    protected virtual void Flying()
    {
        bool reached = false;

        progress += speed * Time.deltaTime;

        if (progress >= 1.0f)
        {
            progress = 1.0f;
            reached = true;
        }

        transform.localPosition = (destination * progress) + start * (1 - progress);

        if (reached)
        {
            start = destination;
            PickNewRandomDestination();
            progress = 0.0f;
        }
        RotateGameObject(destination, RotationSpeed, rotOffset);
    }
}
