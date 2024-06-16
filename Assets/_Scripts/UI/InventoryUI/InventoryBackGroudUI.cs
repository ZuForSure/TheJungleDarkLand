using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBackGroudUI : InventoryAbstractUI
{
    [Header("Inventory BackGroud UI")]
    [SerializeField] protected List<ItemInventoryUI> itemInventoryUIs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemChild();
    }

    protected virtual void LoadItemChild()
    {
        if (this.itemInventoryUIs.Count >= 1) return;
        foreach (Transform child in this.transform)
        {
            ItemInventoryUI itemInventoryUI = child.GetComponent<ItemInventoryUI>();
            this.itemInventoryUIs.Add(itemInventoryUI);
        }
        Debug.Log(transform.name + ": LoadInventoryUI", gameObject);
    }

    public virtual void SetItemInventoryFormPlayer()
    {
        if (this.itemInventoryUIs.Count != this.inventoryUI.PlayerInventory.ItemInventoryList.Count) return;

        for(int i = 0; i < this.itemInventoryUIs.Count; i++)
        {
            itemInventoryUIs[i].SetIconFormInventory(this.inventoryUI.PlayerInventory.ItemInventoryList[i]);
        }
    }
}
