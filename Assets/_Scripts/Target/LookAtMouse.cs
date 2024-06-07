using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse: LookAtTarget
{
    [Header("Look At Mouse")]
    [SerializeField] protected Vector3 mousePosition;

    private void LateUpdate()
    {
        this.GetPosition();
        this.AimTarget(this.mousePosition);
    }

    protected virtual void GetPosition()
    {
        this.mousePosition = InputManager.Instance.MouseWorldPos;
        this.mousePosition.z = 0f;
    }
}
