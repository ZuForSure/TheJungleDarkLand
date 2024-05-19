using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : ZuMonoBehaviour
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerController playerCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
