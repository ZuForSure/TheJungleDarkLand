using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : ZuMonoBehaviour
{
    [Header("Enemy Abstract")]
    [SerializeField] protected EnemyController enemyController;

    protected override void LoadComponent()
    {
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.GetComponentInParent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
}
