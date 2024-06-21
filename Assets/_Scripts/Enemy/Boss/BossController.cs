using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    protected override string GetObjByName()
    {
        return EnemyName.AncientStone.ToString();
    }
}
