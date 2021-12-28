using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CollectionItem : IComparable
{
    public string Name;
    public GameObject VisualModel;
    public Sprite Image;
    public string TextInfo;
    public bool IsFavorite;

    public int CompareTo(object obj)
    {
        var item = obj as CollectionItem;

        if (item == null)
        {
            throw new Exception("Not compare");
        }

        return 1;
    }
}