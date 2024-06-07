using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : EnemyController
{
    protected override string GetObjByName()
    {
        return EnemyName.Eagle.ToString();
    }
}
