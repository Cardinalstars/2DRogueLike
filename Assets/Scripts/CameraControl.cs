using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private readonly int panMs = 20;
    private readonly int panSize = 20;
    private readonly float tapSpeed = .5F;
    private float timeLastTap = 0;

    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Camera camera = GetComponent<Camera>();

        if (Input.GetKey("w"))
        {
            pos.y += panMs * Time.deltaTime;
        }
        transform.position = pos;

        if (Input.GetKey("a"))
        {
            pos.x -= panMs * Time.deltaTime;
        }
        transform.position = pos;

        if (Input.GetKey("s"))
        {
            pos.y -= panMs * Time.deltaTime;
        }
        transform.position = pos;

        if (Input.GetKey("d"))
        {
            pos.x += panMs * Time.deltaTime;
        }

        transform.position = pos;

        if (Input.mouseScrollDelta.y > 0)
        {
            camera.orthographicSize -= .5F;
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            camera.orthographicSize += .5F;
        }

        if (Input.GetKeyDown("space"))
        {

            if (Time.time - timeLastTap < tapSpeed)
            {
                Camera.main.transform.position = GameObject.Find("Player").transform.position;
            }
            timeLastTap = Time.time;
        }
    }
}
