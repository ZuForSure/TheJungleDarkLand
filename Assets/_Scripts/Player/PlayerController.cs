using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ZuMonoBehaviour
{
    [SerializeField] protected PlayerMovement playerMovement;
    [SerializeField] protected PlayerAttack playerAttack;
    public PlayerMovement PlayerMovement => playerMovement;
    public PlayerAttack PlayerAttack => playerAttack;

    protected override void LoadComponent()
    {
        this.LoadPlayerMovement();
        this.LoadPlayerAttack();
    }

    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = transform.GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadPlayerMovement", gameObject);
    }

    protected virtual void LoadPlayerAttack()
    {
        if (this.playerAttack != null) return;
        this.playerAttack = transform.GetComponentInChildren<PlayerAttack>();
        Debug.Log(transform.name + ": LoadPlayerAttack", gameObject);
    }
}
