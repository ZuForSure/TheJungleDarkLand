using System;
using UnityEngine;

public enum ItemName
{
    NoName = 0,

    Rice = 1,
    Tomato = 2,
    Soul = 3,
    Meat = 4,
    Key = 5,
}

public class ItemNameParser
{
    public static ItemName FromString(string itemName)
    {
        try
        {
            return (ItemName)System.Enum.Parse(typeof(ItemName), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemName.NoName;
        }
    }
}
