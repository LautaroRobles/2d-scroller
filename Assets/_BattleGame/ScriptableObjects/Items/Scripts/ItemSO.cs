using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public ItemTypeSO ItemType;
    public string Name;
    [TextArea(15, 20)]
    public string Description;
}
