using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    [Header("Player Damage Sender")]
    [SerializeField] protected int playerDamage = 2;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetPlayerDamage();
    }

    protected virtual void ResetPlayerDamage()
    {
        this.damage = this.playerDamage;
        Debug.Log(transform.name + ": Reset Damage", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.SendDamageToObj(collision.transform);
    }
}
