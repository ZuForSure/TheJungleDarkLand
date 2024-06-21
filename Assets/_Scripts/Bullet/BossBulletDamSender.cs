using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletDamSender : EnemyBulletDamSender
{
    [Header("Boss Bullet Damage Sender")]
    [SerializeField] protected int bossDamage = 5;

    protected override void ResetValue()
    {
        this.ResetBossDamage();
    }

    protected virtual void ResetBossDamage()
    {
        this.damage = this.bossDamage;
        Debug.Log(transform.name + ": ResetBossDamage", gameObject);
    }

    protected override void SpawnFX()
    {
        Vector3 spawnPos = transform.parent.position;
        Quaternion spawnRot = transform.parent.rotation;
        Transform enemyExploision = FXSpawner.Instance.SpawnPrefab(FXSpawner.BossFX, spawnPos, spawnRot);
        enemyExploision.gameObject.SetActive(true);
    }
}
