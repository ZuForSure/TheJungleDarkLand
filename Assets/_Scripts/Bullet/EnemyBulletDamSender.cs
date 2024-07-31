using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamSender : BulletDamageSender
{
    [Header("Enemy Bullet Damage Sender")]
    [SerializeField] protected int bulletDamage = 2;

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
        AudioManager.Instance.PlayExplosionEnemySound();
    }

    protected virtual void SpawnFX()
    {
        Vector3 spawnPos = transform.parent.position;
        Quaternion spawnRot = transform.parent.rotation;

        Transform enemyExploision = FXSpawner.Instance.SpawnPrefab(FXSpawner.EnemyFX, spawnPos, spawnRot);
        enemyExploision.gameObject.SetActive(true);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) return;
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.SpawnFX();
            BulletSpawner.Instance.DespawnToPool(transform.parent);
            AudioManager.Instance.PlayExplosionEnemySound();
        }
        base.OnTriggerEnter2D(collision);
    }
}
