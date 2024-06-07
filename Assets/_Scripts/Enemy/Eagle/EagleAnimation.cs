using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAnimation : EnemyAbstract
{
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
        this.RunAnimation();
        //this.AttackAnimation();
    }

    protected virtual void RunAnimation()
    {
        if (this.enemyController.EnemyDetectCollision.isPlayerComeIn)
        {
            this.animator.SetFloat("Horizontal", this.GetDirection().x);
            this.animator.SetFloat("Vertical", this.GetDirection().y);
        }

        this.animator.SetBool("IsRunning", this.enemyController.EnemyDetectCollision.isPlayerComeIn);
    }

    //protected virtual void AttackAnimation()
    //{
    //    if (this.enemyController.EnemyAttack.isAttaking)
    //    {
    //        this.animator.SetFloat("AttackHorizontal", this.GetDirection().x);
    //        this.animator.SetFloat("AttackVertical", this.GetDirection().y);
    //    }
    //    this.animator.SetBool("isAttacking", this.enemyController.EnemyAttack.isAttaking);
    //}

    protected virtual Vector3 GetDirection()
    {
        this.targetPos = this.enemyController.EnemyFollowPlayer.player.position;
        this.direction = this.targetPos - transform.parent.position;
        this.direction.Normalize();
        return this.direction;
    }
}
