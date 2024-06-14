using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    [Header("Item Spawner")]
    protected static ItemSpawner instance;
    public static ItemSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 ItemSpawner are allowed to exist");
        ItemSpawner.instance = this;
    }

    public virtual void SpawnItem(List<ItemSpawn> itemDropsList, Vector3 dropPos, Quaternion dropRot)
    {
        if (itemDropsList.Count < 1) return;

        ItemName itemName = itemDropsList[0].itemSO.itemName;
        Transform itemDrop = SpawnPrefab(itemName.ToString(), dropPos, dropRot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
