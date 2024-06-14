using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : ZuMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }
}
