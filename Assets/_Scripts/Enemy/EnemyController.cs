using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : ZuMonoBehaviour
{
    [Header("Enemy Controller")]
    [SerializeField] protected EnemySO enemySO;
    [SerializeField] protected EnemyDetectCollision enemyDetect;
    [SerializeField] protected EnemyFollowPlayer enemyFollow;
    [SerializeField] protected EnemyAttack enemyAttack;
    public EnemySO EnemySO => enemySO;
    public EnemyDetectCollision EnemyDetectCollision => enemyDetect;
    public EnemyFollowPlayer EnemyFollowPlayer => enemyFollow;
    public EnemyAttack EnemyAttack => enemyAttack;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadEnemyDetect();
        this.LoadEnemyFollow();
        this.LoadEnemyAttack();
    }

    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string resPath = "Enemy/" + this.GetObjByName();
        this.enemySO = Resources.Load<EnemySO>(resPath);
        Debug.Log(transform.name + ": LoadEnemySO" + resPath, gameObject);
    }

    protected virtual void LoadEnemyDetect()
    {
        if (this.enemyDetect != null) return;
        this.enemyDetect = transform.GetComponentInChildren<EnemyDetectCollision>();
        Debug.Log(transform.name + ": LoadEnemyDetect", gameObject);
    }

    protected virtual void LoadEnemyFollow()
    {
        if (this.enemyFollow != null) return;
        this.enemyFollow = transform.GetComponentInChildren<EnemyFollowPlayer>();
        Debug.Log(transform.name + ": LoadEnemyFollow", gameObject);
    }

    protected virtual void LoadEnemyAttack()
    {
        if (this.enemyAttack != null) return;
        this.enemyAttack = transform.GetComponentInChildren<EnemyAttack>();
        Debug.Log(transform.name + ": LoadEnemyAttack", gameObject);
    }

    protected abstract string GetObjByName();
}
