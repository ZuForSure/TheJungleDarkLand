using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : PlayerAbstract
{
    [Header("Player Attack")]
    [SerializeField] protected Transform hitBox;
    [SerializeField] protected float attackTime = 0.25f;
    [SerializeField] protected float attackTimeCounter = 0f;
    [SerializeField] protected float attackCooldown = 0.5f;
    [SerializeField] protected float attackCooldownCounter = 0f;
    private float attackInput;
    public bool isAttacking = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHitBox();
    }

    protected virtual void LoadHitBox()
    {
        if (this.hitBox != null) return;
        this.hitBox = transform.Find("Hit Box");
        this.hitBox.gameObject.SetActive(false);
        Debug.Log(transform.name + ": LoadHitBox", gameObject);
    }

    protected override void Update()
    {
        this.GetInput();
        this.Attacking();
    }

    protected virtual void GetInput()
    {
        this.attackInput = InputManager.Instance.InputAttack;
    }

    protected virtual void Attacking()
    {
        if (GameController.Instance.isGameOver) return;

        if (this.CanAttack()) 
        { 
            this.StartAttacking();
            AudioManager.Instance.PlaySwingWeaponSound();
        }
        if (this.attackTimeCounter < 0 && this.isAttacking) this.StopAttacking();
        this.AttackTimerDown();
    }

    protected virtual bool CanAttack()
    {
        if (this.attackInput > 0.1f && this.attackCooldownCounter <= 0f) return true;
        return false;
    }

    protected virtual void StartAttacking()
    {
        this.isAttacking = true;
        this.hitBox.gameObject.SetActive(isAttacking);
        this.attackTimeCounter = this.attackTime;
        this.attackCooldownCounter = this.attackCooldown;
    }

    protected virtual void StopAttacking()
    {
        this.isAttacking = false;
        this.hitBox.gameObject.SetActive(isAttacking);
    }

    protected virtual void AttackTimerDown()
    {
        if (this.attackTimeCounter < 0f && this.attackCooldownCounter < 0f) return;
        this.attackTimeCounter -= Time.deltaTime;
        this.attackCooldownCounter -= Time.deltaTime;
    }
}
