using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : EnemyAttack
{
    [Header("Goblin Attack")]
    [SerializeField] protected Transform goblinHitBox;

    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float attackDis = 2f;

    [SerializeField] protected float attackTime = 0.25f;
    [SerializeField] protected float attackTimeCounter = 0f;
    [SerializeField] protected float attackCoolDown = 2f;
    [SerializeField] protected float attackCoolDownCounter = 0f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGoblinHitBox();
    }

    protected override void Update()
    {
        this.Attacking();
    }

    protected virtual void LoadGoblinHitBox()
    {
        if (goblinHitBox != null) return;
        this.goblinHitBox = transform.Find("Goblin Hit Box");
        this.goblinHitBox.gameObject.SetActive(false);
        Debug.Log(transform.name + ": LoadGoblinHitBox", gameObject);
    }

    protected virtual void Attacking()
    {
        if (this.CanAttack()) this.StartAttack();
        if (this.attackTimeCounter < 0 && this.isAttaking == true) this.StopAttack();
        this.TimerDown();
    }

    protected override bool CanAttack()
    {
        if (!this.enemyController.EnemyDetectCollision.isPlayerComeIn) return false;

        this.distance = Vector3.Distance(transform.parent.position, this.player.position);
        if (this.distance < this.attackDis && this.attackCoolDownCounter <= 0f) return true;
        return false;
    }

    protected virtual void StartAttack()
    {
        this.isAttaking = true;

        if (GameController.Instance.isGameOver)
        {
            this.isAttaking = false;
        }

        this.goblinHitBox.gameObject.SetActive(this.isAttaking);
        this.attackTimeCounter = this.attackTime;
        this.attackCoolDownCounter = this.attackCoolDown;
    }

    protected virtual void StopAttack()
    {
        this.isAttaking = false;
        this.goblinHitBox.gameObject.SetActive(this.isAttaking);
    }

    protected virtual void TimerDown()
    {
        if (this.attackTimeCounter < 0 && this.attackCoolDownCounter < 0) return;
        this.attackTimeCounter -= Time.deltaTime;
        this.attackCoolDownCounter -= Time.deltaTime;
    }
}
