using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDamSender : BulletDamageSender
{
    [Header("Player Bullet Damage Sender")]
    [SerializeField] protected int bulletDamage = 5;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetBulletDamage();
    }

    protected virtual void ResetBulletDamage()
    {
        this.damage = this.bulletDamage;
        Debug.Log(transform.name + ": ResetBulletDamage", gameObject);
    }

    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        base.SendDamage(damageReceiver);
        this.SpawnFX();
    }

    protected virtual void SpawnFX()
    {
        Vector3 spawnPos = transform.parent.position;
        Quaternion spawnRot = transform.parent.rotation;
        Transform enemyExploision = FXSpawner.Instance.SpawnPrefab(FXSpawner.PlayerFX, spawnPos, spawnRot);
        enemyExploision.gameObject.SetActive(true);
    }
}
