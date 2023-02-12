using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TMV{
    public class TileMapVisualizer
    {
        public void populateGrid(Tilemap map, TileBase floorTile, float modifier, int mapHeight, int mapWidth)
        {
            map.ClearAllTiles();
            int[,] makeTileArray = PerlinNoiseIslands.islandNoise(mapHeight, mapWidth, modifier);
            Vector3Int floorPosition = new Vector3Int(0, 0, 0);

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (makeTileArray[i, j] == 1)
                    {
                        floorPosition.x = i - mapHeight / 2;
                        floorPosition.y = j - mapHeight / 2;
                        paintTile(floorPosition, map, floorTile);
                    }
                }
            }
        }
        private void paintTile(Vector3Int floorPosition, Tilemap floorTileMap, TileBase tile)
        {
            floorTileMap.SetTile(floorPosition, tile);
        }
    }
}
