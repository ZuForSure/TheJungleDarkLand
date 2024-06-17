using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBackGroudUI : InventoryAbstractUI
{
    [Header("Inventory BackGroud UI")]
    [SerializeField] protected List<ItemInventoryUI> itemInventoryUIs;
    public List<ItemInventoryUI> ItemInventoryUIs => itemInventoryUIs;

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

    public virtual void SetItemInventoryFromPlayer()
    {
        if (this.itemInventoryUIs.Count != this.inventoryUI.PlayerInventory.ItemInventoryList.Count) return;

        for(int i = 0; i < this.itemInventoryUIs.Count; i++)
        {
            this.itemInventoryUIs[i].SetIconFromInventory(this.inventoryUI.PlayerInventory.ItemInventoryList[i]);
        }
    }

}
