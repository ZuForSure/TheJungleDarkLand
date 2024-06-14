using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ItemPickupAble : ItemAbstract
{
    [Header("Item PickupAble")]
    [SerializeField] protected BoxCollider2D boxCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider2D();
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (boxCollider != null) return;
        this.boxCollider = transform.GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadBoxCollider2D", gameObject);
    }

    public virtual void PickedItem()
    {
        ItemSpawner.Instance.DespawnToPool(transform.parent);
    }
}
