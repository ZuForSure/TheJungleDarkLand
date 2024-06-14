using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ZuMonoBehaviour
{
    [SerializeField] protected List<ItemInventory> itemInventoryList;
    [SerializeField] protected int inventorySlots = 10;

    public virtual void AddItem(ItemInventory itemInventory)
    {
        this.itemInventoryList.Add(itemInventory);
    }
}
