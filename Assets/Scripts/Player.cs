using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 playerPositon { get; set; } = new Vector3Int();

    Rigidbody2D myRigidBody;

    private WorldTile selectedTile;

    Grid grid;

    Dictionary<Vector3Int, WorldTile> tiles;

    // Start is called before the first frame update

    void Awake()
    {

    }

    void Start()
    {
        grid = GameTiles.instance.map.layoutGrid;
        tiles = GameTiles.instance.tiles;
        this.AddComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.gravityScale = 0.0f;
        myRigidBody.mass = 0.0f;
        myRigidBody.inertia = 0.0f;

        setSprite();
        SetPlayerStart();
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerLocation();
    }

    private void updatePlayerLocation()
    {
        // this.GetComponent<SpriteRenderer>().transform.position = playerPositon + new Vector3 (.1F, .3F,0);
        if (Input.GetKey(KeyCode.A))
        {
            if (tiles.TryGetValue(getPositionPersonLeft(), out selectedTile))
                myRigidBody.position += (Vector2.left * .01f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (tiles.TryGetValue(getPositionPersonRight(), out selectedTile))
                myRigidBody.position += (Vector2.right * .01f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (tiles.TryGetValue(getPositionPersonUp(), out selectedTile))
                myRigidBody.position += (Vector2.up * .01f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (tiles.TryGetValue(getPositionPersonDown(), out selectedTile))
                myRigidBody.position += (Vector2.down * .01f);
        }

    }
    private void SetPlayerStart()
    {
        System.Random rand = new System.Random();
        myRigidBody.position = GameTiles.instance.worldTilesList[rand.Next(0, GameTiles.instance.positionList.Count - 1)].WorldLocation;
    }
    private void setSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Character") as Sprite;
        this.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }

    Vector3Int getPositionPersonLeft()
    {
        Vector2 point = myRigidBody.position + (Vector2.left * .01f);
        return grid.WorldToCell(point);
    }

    Vector3Int getPositionPersonRight()
    {
        Vector2 point = myRigidBody.position + (Vector2.right * .01f);
        return grid.WorldToCell(point);
    }

    Vector3Int getPositionPersonUp()
    {
        Vector2 point = myRigidBody.position + (Vector2.up * .01f);
        return grid.WorldToCell(point);
    }

    Vector3Int getPositionPersonDown()
    {
        Vector2 point = myRigidBody.position + (Vector2.down * .01f);
        return grid.WorldToCell(point);
    }
}
