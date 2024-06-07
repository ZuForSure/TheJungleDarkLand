using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAtPoint : ZuMonoBehaviour
{
    [SerializeField] protected SpawnerController spawnerCtrl;
    [SerializeField] protected int maxEnemies = 4;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnerCtrl();
    }

    protected override void Start()
    {
        base.Start();
        this.EnemySpawning();
    }

    protected virtual void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = transform.GetComponent<SpawnerController>();
        Debug.Log(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

    protected virtual void EnemySpawning()
    {
        //if (this.ReachLimitEnemies()) return;
        for(int i = 0; i < this.maxEnemies; i++)
        {
            Transform randPoint = this.spawnerCtrl.SpawnPoints.GetRandomPoint();
            Transform randEnemy = this.spawnerCtrl.Spawner.GetRandomPrefab();
            Vector3 randPos = randPoint.position;
            Quaternion randRot = randEnemy.rotation;

            Transform newEnemy = this.spawnerCtrl.Spawner.SpawnPrefab(randEnemy, randPos, randRot);
            newEnemy.gameObject.SetActive(true);
        }
    }

    protected virtual bool ReachLimitEnemies()
    {
        return this.spawnerCtrl.Spawner.spawnCount >= this.maxEnemies;
    }
}
