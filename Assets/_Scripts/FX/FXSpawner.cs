using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    [Header("FX Spawner")]
    protected static FXSpawner instance;
    public static FXSpawner Instance => instance;

    public static string EnemyFX = "EnemyExploision";
    public static string PlayerFX = "PlayerExploision";
    public static string BossFX = "BossExploision";

    protected override void Awake()
    {
        base.Awake();
        if(instance == null)
        {
            FXSpawner.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
