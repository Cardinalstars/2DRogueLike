using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTiles
{ 
    public static GameTiles instance;
    public Tilemap map;
    public List<Vector3Int> positionList = new List<Vector3Int>();
    public List<WorldTile> worldTilesList = new List<WorldTile>();
    public Dictionary<Vector3Int, WorldTile> tiles;

    public GameTiles(Tilemap map)
    {
        this.map = map;

        if (instance == null)
        {
            instance = this;
        }
    }

    public void getWorldTiles()
    {
        tiles = new Dictionary<Vector3Int, WorldTile>();

        foreach (Vector3Int pos in map.cellBounds.allPositionsWithin)
        {
            Vector3Int gridPos = new Vector3Int(pos.x, pos.y, pos.z);

            if (!map.HasTile(gridPos)) continue;

            positionList.Add(gridPos);
            
            WorldTile tile = new WorldTile
            {
                LocalPlace = pos,
                WorldLocation = map.layoutGrid.CellToWorld(pos),
                TileBase = map.GetTile(pos),
                TilemapMember = map,
                Name = pos.x + "," + pos.y
            };
            worldTilesList.Add(tile);

            tiles.Add(tile.LocalPlace, tile);
        }
    }
}
