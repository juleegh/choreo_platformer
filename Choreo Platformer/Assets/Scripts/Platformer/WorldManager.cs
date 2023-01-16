using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance { get { return instance; } }
    private static WorldManager instance;
    private Dictionary<Vector3Int, WorldCell> board;
    [SerializeField] private DanceCharacter character;

    private void Awake()
    {
        instance = this;
        board = new Dictionary<Vector3Int, WorldCell>();
        WorldCell[] cells = GetComponentsInChildren <WorldCell> ();
        foreach (WorldCell cell in cells)
        {
            cell.transform.position = FixedPosition(cell.transform.position);
            board.Add(FixedPosition(cell.transform.position), cell);
            cell.Paint();
        }
    }

    public float GetRequiredTempo()
    {
        if (!board.ContainsKey(FixedPosition(character.transform.position)))
            return 1f;
        return board[FixedPosition(character.transform.position)].RequiredTempo;
    }

    [ContextMenu("Repaint")]
    public void Paint()
    {
        WorldCell[] cells = GetComponentsInChildren<WorldCell>();
        foreach (WorldCell cell in cells)
        {
            cell.transform.position = FixedPosition(cell.transform.position);
            cell.Paint();
        }
    }

    public Vector3Int FixedPosition(Vector3 position)
    {
        return new Vector3Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.z));
    }

    public bool PositionExists(Vector3 position)
    {
        return board.ContainsKey(FixedPosition(position));
    }
}
