using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCell : MonoBehaviour
{
    [SerializeField] private CellType cellType;
    [SerializeField] private CellProperties cellProperties;
    [SerializeField] private CellVisuals visuals;

    public void Paint()
    {
        if (visuals != null)
        { 
            visuals.Paint(cellType);
        }
    }

    private void Start()
    {
        if (visuals != null)
        {
            visuals.SetupNote(cellType);
        }
    }

    public float RequiredTempo
    {
        get
        {
            return cellProperties.RequiredTempo(cellType);
        }
    }
}
