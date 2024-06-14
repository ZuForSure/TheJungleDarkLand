using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbstract : ZuMonoBehaviour
{
    [Header("Item Abstract")]
    [SerializeField] protected ItemController itemCtrl;
    public ItemController ItemController => itemCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemController();
    }

    protected virtual void LoadItemController()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = transform.parent.GetComponent<ItemController>();
        Debug.Log(transform.name + ": LoadItemController", gameObject);
    }
}
