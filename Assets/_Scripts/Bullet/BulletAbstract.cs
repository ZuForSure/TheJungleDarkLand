using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : ZuMonoBehaviour
{
    [SerializeField] protected BulletController bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }
}
