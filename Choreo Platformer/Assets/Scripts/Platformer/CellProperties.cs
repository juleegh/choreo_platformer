using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RotaryHeart.Lib.SerializableDictionary;

public class CellProperties : ScriptableObject
{
    [SerializeField] private CellVisualProperties cellProperties;

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

    public Color GetColor(CellType cellType)
    {
        if (cellProperties.ContainsKey(cellType))
        {
            return cellProperties[cellType].CellColor;
        }
        return Color.black;
    }

    public Sprite GetSprite(CellType cellType)
    {
        if (cellProperties.ContainsKey(cellType))
        {
            return cellProperties[cellType].CellSprite;
        }
        return null;
    }
}

[Serializable]
public class CellVisualProperties : SerializableDictionaryBase<CellType, CellVisualValues> { }
[Serializable]
public class CellVisualValues
{ 
    [SerializeField] private Sprite cellSprite;
    [SerializeField] private Color cellColor;

    public Sprite CellSprite {  get { return cellSprite; } }
    public Color CellColor {  get { return cellColor; } }
}
