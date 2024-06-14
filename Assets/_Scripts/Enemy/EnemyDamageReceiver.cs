using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected EnemyController enemyController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.ReBorn();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.GetComponentInParent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    public override void ReBorn()
    {
        this.maxHP = this.enemyController.EnemySO.hp;
        base.ReBorn();  
    }

    protected override void OnDead()
    {
        this.DespawnEnemy();
        this.SpawnItemOnDead();
    }

    protected virtual void DespawnEnemy()
    {
        EnemySpawner.Instance.DespawnToPool(transform.parent);
    }

    protected virtual void SpawnItemOnDead()
    {
        Vector3 dropPos = transform.parent.position;
        Quaternion dropRot = transform.rotation;
        ItemSpawner.Instance.SpawnItem(this.enemyController.EnemySO.itemSpawnList, dropPos, dropRot);
    }
}
