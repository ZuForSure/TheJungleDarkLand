using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : PlayerAbstract
{
    [Header("Inventory")]
    [SerializeField] protected List<ItemInventory> itemInventoryList;
    [SerializeField] protected int inventorySlots = 10;
    [SerializeField] protected ItemConsume itemConsume;

    public List<ItemInventory> ItemInventoryList => itemInventoryList;
    public ItemConsume ItemConsume => itemConsume;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemConsume();
    }

    protected override void Start()
    {
        base.Start();
        this.AddEmptyItemInventory();
    }

    protected virtual void LoadItemConsume()
    {
        if (this.itemConsume != null) return;
        this.itemConsume = transform.GetComponentInChildren<ItemConsume>();
        Debug.Log(transform.name + ": LoadItemConsume", gameObject);
    }


    protected virtual void AddEmptyItemInventory()
    {
        for(int i = 0; i < this.inventorySlots; i++)
        {
            ItemInventory itemInventory = this.CreateEmptyItemInventory();
            this.itemInventoryList.Add(itemInventory);
        }
    }

    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addCount = itemInventory.itemCount;
        ItemSO itemSO = itemInventory.itemSO;
        ItemName itemName = itemSO.itemName;

        foreach (ItemInventory item in this.itemInventoryList)
        {
            if (item.itemSO == null || item.itemSO.itemName == itemName)
            {
                if (item.itemCount >= item.itemMaxStack) continue;
                item.itemSO = itemSO;
                item.itemCount += addCount;
                return true;
            }
        }
        Debug.Log("can not add");
        return false;
    }

    public virtual void DeductItem(ItemName itemName, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for(int i = this.itemInventoryList.Count - 1; i >= 0; i--)
        {
            if(deductCount <= 0) break;

            itemInventory = this.itemInventoryList[i];
            if(itemInventory.itemSO == null) continue;
            if(itemInventory.itemSO.itemName != itemName) continue;

            if(itemInventory.itemCount < deductCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            } 
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            itemInventory.itemCount -= deduct;
        }

        this.ClearEmptyItem();
    }

    protected virtual ItemInventory CreateEmptyItemInventory()
    {
        ItemInventory emptyItem = new ItemInventory()
        {
            itemSO = null,
            itemCount = 0,
        };
        return emptyItem;   
    }

    protected virtual void ClearEmptyItem() 
    {
        ItemInventory itemIventory;
        for(int i = 0; i < this.itemInventoryList.Count; i++)
        {
            itemIventory = this.itemInventoryList[i];
            if(itemIventory.itemCount == 0) itemIventory.itemSO = null;
        }
    }
}
