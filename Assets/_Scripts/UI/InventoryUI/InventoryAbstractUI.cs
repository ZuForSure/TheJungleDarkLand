using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryAbstractUI : ZuMonoBehaviour
{
    [Header("Inventory Abstract UI")]
    [SerializeField] protected InventoryUI inventoryUI;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventoryUI();
    }

    protected virtual void LoadInventoryUI()
    {
        if (this.inventoryUI != null) return;
        this.inventoryUI = transform.GetComponentInParent<InventoryUI>();
        Debug.Log(transform.name + ": LoadInventoryUI", gameObject);
    }
}
