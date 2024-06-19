using System;
using UnityEngine;

public enum ItemName
{
    NoName = 0,

    Rice = 1,
    Tomato = 2,
    Soul = 3,
    Meat = 4,
    SunKey = 5,
    WaterKey = 6,
    FireKey = 7,
    MoonKey = 8,
    LandKey = 9,
    PlantKey = 10,
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
