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

        if(itemName == ItemName.Meat)
        {
            this.inventory.DeductItem(itemName, consumeCount);
            this.HealPlayerHP(this.hpToHeal);
            return;
        }   

        if (itemName == ItemName.Soul)
        {
            this.inventory.DeductItem(itemName, consumeCount);
            this.HealPlayerHP(2);
            return;
        }
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
