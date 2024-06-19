using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : ZuMonoBehaviour
{
    [SerializeField] protected Collider2D collid2D;
    public int damage = 1;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (this.collid2D != null) return;
        this.collid2D = transform.GetComponent<Collider2D>();
        Debug.Log(transform.name + ": LoadCollider2D", gameObject);
    }

    protected virtual void SendDamageToObj(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.SendDamage(damageReceiver);
    }

    protected virtual void SendDamage(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHP(this.damage);
    }
}
