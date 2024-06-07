using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : EnemyAbstract
{
    [Header("Enemy Attack")]
    [SerializeField] protected Transform player;
    public bool isAttaking;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    protected virtual bool CanAttack()
    {
        return false;
    }
}
