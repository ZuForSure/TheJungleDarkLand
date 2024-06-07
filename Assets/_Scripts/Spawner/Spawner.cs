using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : ZuMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    public int spawnCount = 0;
    public List<Transform> Prefabs => prefabs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
        this.LoadPrefabs();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefab = transform.Find("Prefab");
        foreach (Transform child in prefab)
        {
            this.prefabs.Add(child);
        }
        this.HidePrefab();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefab()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform SpawnPrefab(string prefabName, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newPrefab = this.GetObjectByName(prefabName);
        if (newPrefab == null)
        {
            Debug.LogWarning("Prefab not found: ", newPrefab);
            return null;
        }

        return this.SpawnPrefab(newPrefab, spawnPos, spawnRot);
    }

    public virtual Transform SpawnPrefab(Transform prefab, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, spawnRot);

        newPrefab.parent = this.holder;
        return newPrefab;
    }

    public virtual void DespawnToPool(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    protected virtual Transform GetObjectFromPool(Transform obj)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == obj.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(obj);
        newPrefab.name = obj.name;
        this.spawnCount++;
        return newPrefab;
    }

    protected virtual Transform GetObjectByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }

    public virtual Transform GetRandomPrefab()
    {
        int randPrefab = Random.Range(0, this.prefabs.Count);
        return this.prefabs[randPrefab];
    }
}