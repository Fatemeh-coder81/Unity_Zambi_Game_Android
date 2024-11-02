using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Dictionary<Vector3Int, bool> gridPositions = new Dictionary<Vector3Int, bool>();

    public bool IsPositionOccupied(Vector3Int position)
    {
        return gridPositions.ContainsKey(position) && gridPositions[position];
    }

    public void OccupyPosition(Vector3Int position)
    {
        gridPositions[position] = true;
    }

    public void FreePosition(Vector3Int position)
    {
        gridPositions[position] = false;
    }
}
