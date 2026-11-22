using UnityEngine;

public class DynamicGrid : MonoBehaviour
{
    public Vector3[,] nodes;
    float cellWidth;
    float cellHeight;
    
    public void InitializeGrid(Vector3 gridSize, int numberOfColumns, int numberOfRows)
    {
        nodes = new Vector3[numberOfColumns,numberOfRows];
        Vector3 BottomLeft = transform.position - new Vector3(gridSize.x / 2, gridSize.y / 2, 0);
        cellWidth = gridSize.x / numberOfColumns;
        cellHeight = gridSize.y / numberOfRows;
        // Debug.Log(gridSize);
        // Debug.Log($"the cell width is {cellWidth} and cellHeight is {cellHeight}");

        for (int x = 0; x < numberOfColumns; x++)
        {
            for (int y = 0; y < numberOfRows; y++)
            {
                Vector3 cellCenter = BottomLeft + new Vector3(cellWidth * x + cellWidth / 2, cellHeight * y + cellHeight / 2, 0);
                nodes[x,y] = cellCenter;
            }
        }
    }
}