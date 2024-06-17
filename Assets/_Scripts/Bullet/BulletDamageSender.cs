using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [Header("Bullet Damage Sender")]
    [SerializeField] protected BulletController bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }

    protected override void SendDamage(DamageReceiver damageReceiver)
    {
        base.SendDamage(damageReceiver);
        this.DespawnBullet();
    }

    protected virtual void DespawnBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObj();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent == bulletCtrl.Shooter) return;
        this.SendDamageToObj(collision.transform);
    }
}
