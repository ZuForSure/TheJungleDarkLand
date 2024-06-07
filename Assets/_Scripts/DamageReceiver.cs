using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : ZuMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected int maxHP = 3;
    [SerializeField] protected int hp = 3;
    [SerializeField] protected bool isDead = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider2D();
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        Debug.Log(transform.name + ": LoadBoxCollider2D", gameObject);
    }

    public virtual void DeductHP(int deduct)
    {
        if (this.IsDead()) return;

        this.hp -= deduct;
        if(this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    public virtual void ReBorn()
    {
        this.hp = this.maxHP;
        this.isDead = false;
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
