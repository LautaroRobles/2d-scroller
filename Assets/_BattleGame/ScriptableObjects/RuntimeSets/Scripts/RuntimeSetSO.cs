using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSetSO<T> : ScriptableObject
{
    private List<T> _items = new List<T>();
    public void Initialize()
    {
        _items.Clear();
    }
    public T GetItem(int index)
    {
        return _items[index];
    }
    public void Add(T item)
    {
        if (!_items.Contains(item))
        {
            _items.Add(item);
        }
    }
    public void Remove(T item)
    {
        if (_items.Contains(item))
        {
            _items.Remove(item);
        }
    }
    public int Count()
    {
        return _items.Count;
    }
}