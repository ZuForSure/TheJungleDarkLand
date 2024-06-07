using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : ZuMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected SpawnPoints spawnPoints;
    public Spawner Spawner => spawner;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = Transform.FindAnyObjectByType<SpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
