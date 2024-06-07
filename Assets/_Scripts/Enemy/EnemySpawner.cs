using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("Enemy Spawner")]
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 BulletSpawner are allowed to exist");
        EnemySpawner.instance = this;
    }

}
