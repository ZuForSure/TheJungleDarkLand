using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : EnemyController
{
    protected override string GetObjByName()
    {
        return EnemyName.Goblin.ToString();
    }
}
