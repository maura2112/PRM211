using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;

    private void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, rot_z + 90);
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);
        transform.parent.position = newPos;
    }

}
