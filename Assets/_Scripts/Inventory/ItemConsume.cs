using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConsume : InventoryAbstract
{
    [SerializeField] protected int hpToHeal = 1;

    public void ConSume(ItemInventory itemInventory)
    {
        int consumeCount = itemInventory.itemCount;
        ItemSO itemSO = itemInventory.itemSO;
        ItemName itemName = itemSO.itemName;
        ItemType itemType = itemSO.itemType;

        if (itemType != ItemType.Food) return;
        if (!this.CanConsumeItem()) return;

        this.inventory.DeductItem(itemName, consumeCount);
        this.HealPlayerHP(this.hpToHeal);
    }

    protected virtual bool CanConsumeItem()
    {
        return this.inventory.PlayerCtrl.PlayerDamageReceiver.hp < this.inventory.PlayerCtrl.PlayerDamageReceiver.maxPlayerHP;
    }

    protected virtual void HealPlayerHP(int healing)
    {
        this.inventory.PlayerCtrl.PlayerDamageReceiver.hp += healing;
    }

}
