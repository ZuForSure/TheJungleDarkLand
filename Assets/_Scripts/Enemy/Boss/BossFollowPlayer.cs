using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayer : EnemyFollowPlayer
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 1.5f;
    }
}

