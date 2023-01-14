using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellVisuals : MonoBehaviour
{
    [SerializeField] private SpriteRenderer noteRenderer;
    [SerializeField] private SpriteRenderer backgroundRenderer;
    [SerializeField] private CellProperties cellProperties;
    private CellType cellType;
    private Color inTempo;
    private Color offTempo;

    public void Paint(CellType note)
    { 
        backgroundRenderer.color = cellProperties.GetColor(note);
        noteRenderer.sprite = cellProperties.GetSprite(note);
    }

    public void SetupNote(CellType note)
    {
        cellType = note;
        noteRenderer.sprite = cellProperties.GetSprite(cellType);
        inTempo = cellProperties.GetColor(cellType);
        offTempo = inTempo;
        offTempo.a = 0.3f;
    }

    private void Update()
    {
        float alpha = cellProperties.RequiredTempo(cellType) - TempoCounter.Instance.CurrentBeatPercentage;
        Color color = inTempo;
        color.a = alpha;
        backgroundRenderer.color = color;
    }
}
