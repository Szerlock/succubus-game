using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{

  [SerializeField]
  private SimpleRandomData randonWalkParameters;

  protected override void RunProceduralGeneration()
  {
    HashSet<Vector2Int> floorPositions = RunRandomWalk();
    tilemapVisualizer.Clear();
    tilemapVisualizer.PaintFloorTiles(floorPositions);
    WallGeneratir.CreateWalls(floorPositions, tilemapVisualizer);
  }

  protected HashSet<Vector2Int> RunRandomWalk()
  {
    var currentPosition = startPosition;
    HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
    for(int i = 0; i < randonWalkParameters.iterations; i++)
    {
      var path = ProceduralGenerationAlgorithm.SimpleRandomWalk(currentPosition, randonWalkParameters.walkLength);
      floorPositions.UnionWith(path);
      if(randonWalkParameters.startRandomlyEachIteration)
        currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
    }
    return floorPositions;      
  }
}
