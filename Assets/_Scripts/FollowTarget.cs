using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected Transform target;

    private void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        transform.position = Vector3.Lerp(transform.position, this.target.position, this.speed * Time.fixedDeltaTime);
    }
}
