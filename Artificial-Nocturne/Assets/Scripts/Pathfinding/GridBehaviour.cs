using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
    //public Transform Player;

    public bool onlyDisplayGizmos;
    public LayerMask unwalkableMask;
    public Vector3 gridWorldSize;
    public Vector3 worldBottomLeft;
    public float nodeRadius;
    Node[,] grid;

    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;

    //=====================================================================

    public static int nodeCount;

    public GameObject background;
    // public GameObject node;
    public static GameObject[] allNodes;

    // public Vector3 newPos;
    // public static Vector3[] vertices;

    // public Transform wayStation;
    // public Transform backgroundPos;

    public static bool stepOne = false;
    private new Renderer renderer;

    /* Note: When scaling for larger or smaller sized play maps gridSizeX, gridSizeY, vertices[i], and newPos must all be adjusted. 
     * Here we have gridSizeX and gridSizeY divided by 10 to reduce the overall amount of nodes generated.
     * Next we multiply the X and Y parameter in vertices[i] by 10 to increase the space between nodes.
     * Finally, when setting the nodes waystation to be positioned center on the game space we divide by 19.5 to give the closest adjustment to center.
     * When scaling up for a larger map (for larger game assets, not just a larger gamespace) both instances of ten can be increased to 100 while 19.5 can be increased to 195. 
     * Scaling down is the opposite resulting in 1 and 19.5
    */

    void Awake()
    {
        renderer = background.GetComponent<Renderer>();
        nodeDiameter = nodeRadius * 2;
        gridWorldSize.x = Mathf.RoundToInt(renderer.bounds.size.x);
        gridWorldSize.y = Mathf.RoundToInt(renderer.bounds.size.y);
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        //  gridWorldSize = new Vector3(gridSizeX, gridSizeY, 1);
        Generate();
    }

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }

    private void Generate()
    {
        grid = new Node[gridSizeX, gridSizeY];
        worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;
        //worldBottomLeft = new Vector3(worldBottomLeft.x, worldBottomLeft.y, worldBottomLeft.z * 0);
   

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics2D.OverlapPoint(worldPoint, unwalkableMask));
                grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    public List<Node> GetNeighbors(Node node)
    // Here we determine which nodes are neighbors to our current node
    {
        List<Node> neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;


                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbors.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbors;
    }


    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }


    private void OnDrawGizmos()
    // Here we draw the grid and mark off that which is walkable/unwalkable
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));
        {

            if (grid != null && onlyDisplayGizmos)
            {
                foreach (Node n in grid)
                {
                    Gizmos.color = (n.walkable) ? Color.white : Color.red;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
                }
            }
        }
    }
}