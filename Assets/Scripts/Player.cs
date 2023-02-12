using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 playerPositon { get; set; } = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {

        this.AddComponent<SpriteRenderer>();

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
        this.GetComponent<SpriteRenderer>().transform.position = playerPositon + new Vector3 (.1F, .3F,0);
        
    }
    private void SetPlayerStart()
    {
        System.Random rand = new System.Random();
        playerPositon = GameTiles.instance.worldTilesList[rand.Next(0, GameTiles.instance.positionList.Count - 1)].WorldLocation;
    }
    private void setSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Character") as Sprite;
        this.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
}
