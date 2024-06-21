using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [Header("Bullet Spawner")]
    protected static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public static string bulletOne = "Bullet_1";
    public static string arrow = "Arrow";
    public static string cross = "Crossed";

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
        {
            BulletSpawner.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
