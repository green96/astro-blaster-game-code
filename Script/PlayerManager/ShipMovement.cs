using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 0.1f;

    private void FixedUpdate()
    {
        this.GetTargetPos();
        this.Moving();
    }

    protected virtual void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MouseWorldPos;
        this.targetPos.z = 0;
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPos, this.speed);
        transform.parent.position = newPos;
    }


}
