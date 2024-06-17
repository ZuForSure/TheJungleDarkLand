using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ZuMonoBehaviour
{
    //[SerializeField] protected PlayerMovement playerMovement;
    [SerializeField] protected PlayerAttack playerAttack;
    [SerializeField] protected PlayerDamageReceiver playerDamReceiver;
    //public PlayerMovement PlayerMovement => playerMovement;
    public PlayerAttack PlayerAttack => playerAttack;
    public PlayerDamageReceiver PlayerDamageReceiver => playerDamReceiver;

    protected override void LoadComponent()
    {
        //this.LoadPlayerMovement();
        this.LoadPlayerAttack();
        this.LoadPlayerDamageReceiver();
    }

    //protected virtual void LoadPlayerMovement()
    //{
    //    if (this.playerMovement != null) return;
    //    this.playerMovement = transform.GetComponentInChildren<PlayerMovement>();
    //    Debug.Log(transform.name + ": LoadPlayerMovement", gameObject);
    //}

    protected virtual void LoadPlayerAttack()
    {
        if (this.playerAttack != null) return;
        this.playerAttack = transform.GetComponentInChildren<PlayerAttack>();
        Debug.Log(transform.name + ": LoadPlayerAttack", gameObject);
    }

    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamReceiver != null) return;
        this.playerDamReceiver = transform.GetComponentInChildren<PlayerDamageReceiver>();
        Debug.Log(transform.name + ": LoadPlayerDamageReceiver", gameObject);
    }
}
