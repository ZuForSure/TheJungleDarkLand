using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ZuMonoBehaviour
{
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;

    protected override void LoadComponent()
    {
        this.LoadPlayerMovement();
    }

    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = transform.GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadPlayerMovement", gameObject);
    }
}
