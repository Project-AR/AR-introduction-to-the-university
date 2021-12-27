using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseData : ScriptableObject
{
    public abstract int DataKey { get; }
}
