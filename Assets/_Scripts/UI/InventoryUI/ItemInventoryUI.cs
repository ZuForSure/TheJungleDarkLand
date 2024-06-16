using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryUI : ZuMonoBehaviour
{
    [SerializeField] protected Image icon;
    [SerializeField] protected Text quatity;

    public virtual void SetIconFormInventory(ItemInventory itemInventory)
    {
        if(itemInventory.itemSO != null)
        {
            this.icon.sprite = itemInventory.itemSO.itemSprite;
            this.quatity.text = itemInventory.itemCount.ToString();
        }
        else
        {
            this.icon.sprite = null;
            this.quatity.text = "";
        }
    }
}
