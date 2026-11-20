using UnityEngine;
using System.Collections.Generic;

public class DynamicGrid : MonoBehaviour
{
    public List<Vector3> nodes = new List<Vector3>();
    float cellWidth;
    float cellHeight;
    
    public void InitializeGrid(Vector3 gridSize, int numberOfColumns, int numberOfRows)
    {
        Vector3 BottomLeft = transform.position - new Vector3(gridSize.x / 2, gridSize.y / 2, 0);
        cellWidth = gridSize.x / numberOfColumns;
        cellHeight = gridSize.y / numberOfRows;

        for (int x = 0; x < numberOfColumns; x++)
        {
            for (int y = 0; y < numberOfRows; y++)
            {
                Vector3 cellCenter = BottomLeft + new Vector3(cellWidth * x + cellWidth / 2, cellHeight * y + cellHeight / 2, 0);
                nodes.Add(cellCenter);
            }
        }
    }
}