using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectionItemData", menuName = "GameData/CollectionItemData", order = 1)]
public class CollectionItemData : BaseData
{
    public int Id;
    public override int DataKey => Id;

    public CollectionItem Data;
}
