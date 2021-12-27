using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "Collection", menuName = "GameData/Collection", order = 1)]
public class UserCollection : ScriptableObject
{
    [SerializeField] private List<int> itemsId = new List<int>();

    public void Add(int item)
    {
        itemsId.Add(item);
    }

    public bool Remove(int item)
    {
        return itemsId.Remove(item);
    }

    public void RemoveByIndex(int index)
    {
        if (!IsValidIndex(index))
        {
            throw new System.ArgumentOutOfRangeException();
        }

        itemsId.RemoveAt(index);
    }


    public List<CollectionItemData> GetItems()
    {
        return DataManager.GetAll<CollectionItemData>().ToList();
    }

    /*
    public List<CollectionItem> GetSortedCollectionByName(bool considerFavorites = false)
    {
        itemsId.Sort();
        return itemsId;
    }*/

    public List<CollectionItemData> GetFavorites()
    {
        return GetItems().Where(t => itemsId.Contains(t.Id) && t.Data.IsFavorite).ToList(); 
    }

    public void SetFavorite(int index, bool isFavorite)
    {
        if (!IsValidIndex(index))
        {
            throw new System.ArgumentOutOfRangeException();
        }

        DataManager.GetData<CollectionItemData>(index).Data.IsFavorite = isFavorite;
    }

    private bool IsValidIndex(int index)
    {
        return index >= 0 && index < itemsId.Count;
    }
}