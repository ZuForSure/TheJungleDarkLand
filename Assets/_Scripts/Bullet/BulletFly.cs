using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float flySpeed = 20f;
    [SerializeField] protected Vector3 directionFly = Vector3.right;

    private void FixedUpdate()
    {
        this.Flying();
    }

    protected virtual void Flying()
    {
        transform.parent.Translate(this.directionFly * this.flySpeed * Time.fixedDeltaTime);
    }
}
