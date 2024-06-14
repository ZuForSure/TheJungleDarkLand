using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    public ItemName itemName;
    public ItemType itemType;
    public float maxDropRate = 100f;
    public int maxStack = 10;

    public static ItemSO FindByItemName(ItemName itemName)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemSO));
        foreach (ItemSO profile in profiles)
        {
            if (profile.itemName != itemName) continue;
            return profile;
        }
        return null;
    }
}
