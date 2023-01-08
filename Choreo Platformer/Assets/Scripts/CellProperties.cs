using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RotaryHeart.Lib.SerializableDictionary;

public class CellProperties : ScriptableObject
{
    [SerializeField] private CellSprites cellSprites;
    public CellSprites CellSprites { get { return cellSprites; } }

    public float RequiredTempo(CellType cellType)
    {
        switch (cellType)
        {
            case CellType.Black:
                return 1f;
            case CellType.Half:
                return 0.5f;
            case CellType.Quarter:
                return 0.25f;
        }
        return 0f;
    }
}

[Serializable]
public class CellSprites : SerializableDictionaryBase<CellType, Sprite> { }
