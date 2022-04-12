using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    [SerializeField] private List<ItemSO> _items = new List<ItemSO>();
    public int Slots;
    public void Add(ItemSO item)
    {
        if (_items.Count >= Slots)
            return;

        _items.Add(item.Clone());
    }
    public void Remove(ItemSO item)
    {
        if (_items.Count == 0)
            return;

        _items.Remove(item.Clone());
    }
    public int Count()
    {
        return _items.Count;
    }
    public ItemSO GetItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= _items.Count)
        {
            Debug.LogError("itemIndex: " + itemIndex + " not found in _items");
            return null;
        }
        return _items[itemIndex];
    }
}
