using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class HexSelector : MonoBehaviour
{
    private WorldTile selectedTile;
    private Grid grid;
    private TileBase prevTile;
    private Vector3Int previousPosition;
    private bool firstUpdate = true;
    void Start()
    {
        grid = GameTiles.instance.map.layoutGrid;
    }

    // Update is called once per frame
    void Update()
    {
        Dictionary<Vector3Int, WorldTile> tiles = GameTiles.instance.tiles;

        if(tiles.TryGetValue(getMousePosition(), out selectedTile) && previousPosition != getMousePosition())
        {
            prevTile = selectedTile.TileBase;
            selectedTile.TilemapMember.SetTileFlags(selectedTile.LocalPlace, TileFlags.None);
            selectedTile.TilemapMember.SetColor(selectedTile.LocalPlace, Color.red);

            if (firstUpdate)
            {
                firstUpdate = false;
            }
            else
            {
                selectedTile.TilemapMember.SetColor(previousPosition, Color.white);
            }
            previousPosition = selectedTile.LocalPlace;
        }
    }

    Vector3Int getMousePosition()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(point);
    }
}
