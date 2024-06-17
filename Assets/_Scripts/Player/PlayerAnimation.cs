using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : PlayerAbstract
{
    [Header("Player Animation")]
    public Animator animator;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.Animation();
    }

    protected virtual void Animation()
    {
        this.MoveAnimation();
        this.RunAniamtion();
        this.AttackAnimation();
        this.DeathAnimation();
    }

    protected virtual void MoveAnimation()
    {
        if (this.CanMoving())
        {
            this.animator.SetFloat("Horizontal", InputManager.Instance.InputHorizontal);
            this.animator.SetFloat("Vertical", InputManager.Instance.InputVertical);
        }
    }

    protected virtual void RunAniamtion()
    {
        this.animator.SetBool("IsRunning", this.CanMoving());
    }

    protected virtual void AttackAnimation()
    {
        if (this.playerCtrl.PlayerAttack.isAttacking)
        {
            Vector3 direction = InputManager.Instance.MouseWorldPos - transform.parent.position;
            direction.z = 0f;
            direction.Normalize();

            this.animator.SetFloat("AttackHorizontal", direction.x);
            this.animator.SetFloat("AttackVertical", direction.y);
        }
        this.animator.SetBool("IsAttaking", this.playerCtrl.PlayerAttack.isAttacking);
    }
    protected virtual void DeathAnimation()
    {
        this.animator.SetBool("IsGameOver", GameController.Instance.isGameOver);
    }

    protected virtual bool CanMoving()
    {
        float horizontal = InputManager.Instance.InputHorizontal;
        float vertical = InputManager.Instance.InputVertical;
        Vector2 input = new(horizontal, vertical);

        if (input.magnitude > 0.1f) return true;
        return false;
    }
}
