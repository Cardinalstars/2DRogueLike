using System.Collections;
using System.Collections.Generic;
using TMV;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    Tilemap map;

    [SerializeField]
    TileBase tile;


    TileMapVisualizer tileMapVisualizer = new TileMapVisualizer();


    Player player;
    HexSelector selector;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = new GameObject("Player");
        player = Player.AddComponent<Player>();
        player.gameObject.AddComponent<Rigidbody2D>();
        player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        tileMapVisualizer.populateGrid(map, tile, 0.05F, 100, 100);

        GameTiles gameTiles = new GameTiles(map);
        gameTiles.getWorldTiles();

        // Camera Creation
        GameObject MainCam = new GameObject("MainCamera");
        camera = MainCam.AddComponent<Camera>();
        camera.AddComponent<CameraControl>();
        camera.tag = "MainCamera";
        camera.orthographic = true;
        camera.nearClipPlane = 0.0F;


        GameObject HexSelector = new GameObject("HexSelector");
        selector = HexSelector.AddComponent<HexSelector>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

