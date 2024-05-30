using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [Header("Bullet Spawner")]
    protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public static string bulletOne = "Bullet_1";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 BulletSpawner are allowed to exist");
        BulletSpawner.instance = this;
    }
}
