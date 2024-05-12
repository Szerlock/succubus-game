using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Graph
{
    private static List<Vector2Int> neighbour4Directions = new List<Vector2Int>
    {
        new Vector2Int(0, 1), //up
        new Vector2Int(1, 0), //Right
        new Vector2Int(0, -1), // Down 
        new Vector2Int(-1, 0)  // Left
    };

    public static List<Vector2Int> neighBour8Directions = new List<Vector2Int>
    {
        new Vector2Int(0, 1), //UP
        new Vector2Int(1, 1), //UP - right


        new Vector2Int(1, 0), //RIGHT
        new Vector2Int(1, -1), //RIGHT - down


        new Vector2Int(0, -1), //DOWN
        new Vector2Int(-1, -1), //DOWN - left


        new Vector2Int(-1, 0), //LEFT
        new Vector2Int(-1, 1) //LEFT - up

    };

    List<Vector2Int> graph;

    public Graph(IEnumerable<Vector2Int> vertices)
    {
        graph = new List<Vector2Int>(vertices);
    }

    public List<Vector2Int> GetNeighbours4Directions(Vector2Int startPosition)
    {
        return GetNeighbours(startPosition, neighbour4Directions);
    }

    public List<Vector2Int> GetNeighbours8Directions(Vector2Int startPosition)
    {
        return GetNeighbours(startPosition, neighbour4Directions);
    }

    private List<Vector2Int> GetNeighbours(Vector2Int startPosition, List<Vector2Int> neighbourOffsetList)
    {
        List<Vector2Int> neighbours = new List<Vector2Int>();
        foreach (var neighbourDirection in neighbourOffsetList)
        {
            Vector2Int potentialNeighbour = startPosition + neighbourDirection;
            if(graph.Contains(potentialNeighbour))
            {
                neighbours.Add(potentialNeighbour);
            }
        }
        return neighbours;
    }
}
