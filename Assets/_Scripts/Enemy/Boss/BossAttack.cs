using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    [Header("Boss Attack")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 1.5f;

    protected override void Update()
    {
        base.Update();
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.CanAttack()) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0f;

        Vector3 pos = transform.parent.position;
        Quaternion rot = transform.rotation;
        Transform cross = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.cross, pos, rot);
        if (cross == null) return;

        cross.gameObject.SetActive(true);
        BulletController bulletCtrl = cross.GetComponent<BulletController>();
        bulletCtrl.SetShooter(transform.parent);
    }

    protected override bool CanAttack()
    {
        this.isAttaking = this.enemyController.EnemyDetectCollision.isPlayerComeIn;
        if (GameController.Instance.isGameOver) this.isAttaking = false;

        return this.isAttaking;   
    }
}
