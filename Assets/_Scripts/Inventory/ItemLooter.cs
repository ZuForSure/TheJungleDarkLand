using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class ItemLooter : InventoryAbstract
{
    [Header("Item Looter")]
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected Rigidbody2D rb2D;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider2D();
        this.LoadRigibody2D();
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (boxCollider != null) return;
        this.boxCollider = transform.GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadBoxCollider2D", gameObject);
    }

    protected virtual void LoadRigibody2D()
    {
        if (rb2D != null) return;
        this.rb2D = transform.GetComponent<Rigidbody2D>();
        this.rb2D.isKinematic = true;
        this.rb2D.gravityScale = 0;
        Debug.Log(transform.name + ": LoadRigibody2D", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemPickupAble itemPickUp = other.GetComponent<ItemPickupAble>();
        if (itemPickUp == null) return;

        ItemInventory itemInventory = itemPickUp.ItemController.ItemInventory;
        this.inventory.AddItem(itemInventory);

        itemPickUp.PickedItem();
    }
}
