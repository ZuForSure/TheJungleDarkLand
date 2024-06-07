using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [Header("Enemy Damage Sender")]
    [SerializeField] protected EnemyController enemyController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.SetDamage();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.parent.GetComponentInParent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void SetDamage()
    {
        this.damage = this.enemyController.EnemySO.damageMax;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.SendDamageToObj(collision.transform);
    }
}
