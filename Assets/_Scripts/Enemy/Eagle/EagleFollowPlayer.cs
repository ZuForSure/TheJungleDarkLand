using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFollowPlayer : EnemyFollowPlayer
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 1f;
    }
}

