using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ZuMonoBehaviour
{
    [SerializeField] protected PlayerAttack playerAttack;
    [SerializeField] protected PlayerDamageReceiver playerDamReceiver;
    [SerializeField] protected PlayerShooting playerShooting;
    [SerializeField] protected Rigidbody2D rd2D;
    public PlayerAttack PlayerAttack => playerAttack;
    public PlayerDamageReceiver PlayerDamageReceiver => playerDamReceiver;
    public PlayerShooting PlayerShooting => playerShooting;
    public Rigidbody2D Rd2D => rd2D;

    protected override void LoadComponent()
    {
        this.LoadPlayerAttack();
        this.LoadPlayerShooting();
        this.LoadPlayerDamageReceiver();
        this.LoadRigi2D();
    }

    protected virtual void LoadPlayerAttack()
    {
        if (this.playerAttack != null) return;
        this.playerAttack = transform.GetComponentInChildren<PlayerAttack>();
        Debug.Log(transform.name + ": LoadPlayerAttack", gameObject);
    }

    protected virtual void LoadPlayerShooting()
    {
        if (this.playerShooting != null) return;
        this.playerShooting = transform.GetComponentInChildren<PlayerShooting>();
        Debug.Log(transform.name + ": LoadPlayerShooting", gameObject);
    }

    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamReceiver != null) return;
        this.playerDamReceiver = transform.GetComponentInChildren<PlayerDamageReceiver>();
        Debug.Log(transform.name + ": LoadPlayerDamageReceiver", gameObject);
    }

    protected virtual void LoadRigi2D()
    {
        if (this.rd2D != null) return;
        this.rd2D = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigi2D", gameObject);
    }
}
