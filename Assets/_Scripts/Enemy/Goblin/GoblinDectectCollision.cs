using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class GoblinDectectCollision : EnemyDetectCollision
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetRadius();
    }

    protected virtual void ResetRadius()
    {
        this.detectRadius = 3f;
        this.circleCollider2D.radius = this.detectRadius;
        Debug.Log(transform.name + ": ResetRadius", gameObject);
    }
}
