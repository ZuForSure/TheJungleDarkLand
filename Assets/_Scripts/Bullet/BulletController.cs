using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : ZuMonoBehaviour
{
    [SerializeField] protected BulletDespawn bulletDespawn;
    [SerializeField] protected Transform shooter;
    public BulletDespawn BulletDespawn => bulletDespawn;
    public Transform Shooter => shooter;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
