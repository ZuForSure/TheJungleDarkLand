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

        if (this.CanMoving())
        {
            this.animator.SetFloat("Horizontal", InputManager.Instance.GetInputHorizontal());
            this.animator.SetFloat("Vertical", InputManager.Instance.GetInputVertical());
        }

        this.animator.SetBool("IsRunning", this.CanMoving());
        this.animator.SetBool("IsDashing", this.playerCtrl.PlayerMovement.isDashing);
    }

    protected virtual bool CanMoving()
    {
        float horizontal = InputManager.Instance.GetInputHorizontal();
        float vertical = InputManager.Instance.GetInputVertical();
        Vector2 input = new(horizontal, vertical);

        if (input.magnitude > 0.1f) return true;
        return false;
    }
}
