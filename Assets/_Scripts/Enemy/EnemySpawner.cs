using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("Enemy Spawner")]
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
        {
            EnemySpawner.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


