using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse: MonoBehaviour
{
    [SerializeField] protected Vector3 mousePosition;

    private void Update()
    {
        this.GetPosition();
        this.RotateFollowTarget();
    }

    protected virtual void GetPosition()
    {
        this.mousePosition = InputManager.Instance.MouseWorldPos;
        this.mousePosition.z = 0f;
    }

    protected virtual void RotateFollowTarget()
    {
        Vector3 diff = this.mousePosition - this.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
