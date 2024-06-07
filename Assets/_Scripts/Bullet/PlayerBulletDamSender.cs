using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDamSender : BulletDamageSender
{
    [Header("Player Bullet Damage Sender")]
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
}
