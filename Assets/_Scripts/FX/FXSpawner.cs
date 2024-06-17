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

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 FXSpawner are allowed to exist");
        FXSpawner.instance = this;
    }
}
