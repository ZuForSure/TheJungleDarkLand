using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinFollowPlayer : EnemyFollowPlayer
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 2f;
    }
}

