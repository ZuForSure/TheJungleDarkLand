using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    protected override void DespawnObj()
    {
        BulletSpawner.Instance.DespawnToPool(transform.parent);
    }
}
