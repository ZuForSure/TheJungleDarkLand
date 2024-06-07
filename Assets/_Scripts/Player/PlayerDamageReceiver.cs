using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [Header("Player Damage Receiver")]
    [SerializeField] protected int maxPlayerHP = 10;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ReBorn();
    }

    public override void ReBorn()
    {
        this.maxHP = this.maxPlayerHP;
        base.ReBorn();
    }

    protected override void OnDead()
    {
        Debug.Log("Player DEAD");
    }
}
