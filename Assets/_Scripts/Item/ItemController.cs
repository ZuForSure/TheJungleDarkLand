using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : ZuMonoBehaviour
{
    [Header("Item Controller")]

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemInventory();
    }

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemSO != null) return;
        ItemName itemName = ItemNameParser.FromString(transform.name);
        ItemSO itemSO = ItemSO.FindByItemName(itemName);
        this.itemInventory.itemSO = itemSO;
        this.itemInventory.itemCount = 1;
        this.itemInventory.itemMaxStack = itemSO.maxStack;
        Debug.Log(transform.name + ": LoadItemInventory", gameObject);
    }

}
