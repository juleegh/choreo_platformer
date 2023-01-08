using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CellType cellType;
    [SerializeField] private CellProperties cellProperties;

    public void Paint()
    {
        spriteRenderer.sprite = cellProperties.CellSprites[cellType];  
    }

    public float RequiredTempo
    {
        get
        {
            return cellProperties.RequiredTempo(cellType);
        }
    }
}
