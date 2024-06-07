using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : FollowPlayer
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 5f;
    }

    protected void LateUpdate()
    {
        this.Following();
    }

    protected override void Following()
    {
        transform.position = Vector3.Lerp(transform.position, this.player.position, this.speed);
    }
}

