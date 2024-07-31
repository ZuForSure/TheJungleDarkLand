using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : EnemyAbstract
{
    [Header("Boss Animation")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected Vector3 direction;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        this.animator = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected override void Update()
    {
        this.Animation();
    }

    protected virtual void Animation()
    {
        this.AttackAnimation();
        //this.DeathAnimation();
    }

    protected virtual void AttackAnimation()
    {
        this.animator.SetBool("IsShooting", this.enemyController.EnemyAttack.isAttaking);
    }

    //protected virtual void DeathAnimation()
    //{
    //    this.animator.SetBool("IsDead", this.enemyController.EnemyDamageReceiver.isDead);
    //}

    protected virtual Vector3 GetDirection()
    {
        this.targetPos = this.enemyController.EnemyFollowPlayer.player.position;
        this.direction = this.targetPos - transform.parent.position;
        this.direction.Normalize();
        return this.direction;
    }
}
