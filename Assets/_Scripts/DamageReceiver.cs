using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : ZuMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected Collider2D colli2D;
    [SerializeField] protected int maxHP = 3;
    public bool isDead = false;
    public int hp = 3;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider2D();
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this.colli2D != null) return;
        this.colli2D = transform.GetComponent<Collider2D>();
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
