using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldTile
{
    public Vector3Int LocalPlace { get; set; }

    public Vector3 WorldLocation { get; set; }

    public TileBase TileBase { get; set; }

    public TileBase Highlighted { get; set; }

    public Tilemap TilemapMember { get; set; }

    public string Name { get; set; }

    public Tile[] Neighbors { get; set; }

    
}
