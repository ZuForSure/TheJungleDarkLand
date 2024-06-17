using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : ZuMonoBehaviour
{
    [SerializeField] protected Inventory playerInventory;
    [SerializeField] protected GameObject titleInventory;
    [SerializeField] protected InventoryBackGroudUI inventoryBackGroudUI;
    public Inventory PlayerInventory => playerInventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerInventory();
        this.LoadInventoryBackGroudUI();
    }

    protected override void Update()
    {
        base.Update();
        this.ToggleInventory();
    }

    protected virtual void LoadPlayerInventory()
    {
        if (this.playerInventory != null) return;
        this.playerInventory = GameObject.Find("Player").GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadPlayerInventory", gameObject);
    }

    protected virtual void LoadInventoryBackGroudUI()
    {
        if (this.inventoryBackGroudUI != null) return;
        this.inventoryBackGroudUI = transform.GetComponentInChildren<InventoryBackGroudUI>();
        Debug.Log(transform.name + ": LoadInventoryBackGroudUI", gameObject);
    }

    protected virtual void ToggleInventory()
    {
        if (GameController.Instance.isGameOver) 
        {
            this.inventoryBackGroudUI.gameObject.SetActive(false);
            this.titleInventory.gameObject.SetActive(false);
            return;
        }

        if (InputManager.Instance.InputInventory)
        {
            this.inventoryBackGroudUI.gameObject.SetActive(true);
            this.titleInventory.gameObject.SetActive(true);
            this.inventoryBackGroudUI.SetItemInventoryFromPlayer();
        }
        else
        {
            this.inventoryBackGroudUI.gameObject.SetActive(false);
            this.titleInventory.gameObject.SetActive(false);
        }
    }

}
