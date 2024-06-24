
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryUI : ZuMonoBehaviour
{
    [SerializeField] protected InventoryBackGroudUI invenBackGroundUI;
    [SerializeField] protected Image icon;
    [SerializeField] protected TextMeshProUGUI quantityText;
    [SerializeField] protected ItemSO itemSO_UI;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventoryBackGroudUI();
    }

    protected virtual void LoadInventoryBackGroudUI()
    {
        if (this.invenBackGroundUI != null) return;
        this.invenBackGroundUI = transform.parent.GetComponent<InventoryBackGroudUI>();
        Debug.Log(transform.name + ": LoadInventoryBackGroudUI", gameObject);
    }

    public virtual void SetIconFromInventory(ItemInventory itemInventory)
    {
        if(itemInventory.itemSO != null)
        {
            this.icon.color = new Color(1, 1, 1, 1);
            this.icon.sprite = itemInventory.itemSO.itemSprite;
            this.quantityText.text = itemInventory.itemCount.ToString();
            this.itemSO_UI = itemInventory.itemSO;
        }
        else
        {
            this.icon.color = new Color(1, 1, 1, 0);
            this.icon.sprite = null;
            this.quantityText.text = "";
            this.itemSO_UI = null;
        }
    }

    public void ConsumeItemByUI()
    {
        if (this.itemSO_UI == null) return;

        ItemInventory itemInventory = new ItemInventory()
        {
            itemSO = this.itemSO_UI,
            itemCount = 1,
            itemMaxStack = this.itemSO_UI.maxStack,
        };

        this.invenBackGroundUI.InventoryUI.PlayerInventory.ItemConsume.ConSume(itemInventory);
    }
}
