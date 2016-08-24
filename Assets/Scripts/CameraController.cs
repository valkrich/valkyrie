﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    // How fast to move the screen when arrows used
    static int keyScrollRate = 30;
    // How much to zoom in/out with wheel
    static int mouseWheelScrollRate = 600;
    // Max zoom in
    static int maxZoom = -100;
    // Max zoom out
    static int minZoom = -2500;

	// FixedUpdate is not tied to frame rate
	void FixedUpdate () {
        // Check if the scroll wheel has moved
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            // Translate the camera up/down
            gameObject.transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * mouseWheelScrollRate), Space.World);

            // Limit how high/low the camera can go
            if (gameObject.transform.position.z > maxZoom)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, maxZoom);
            if (gameObject.transform.position.z < minZoom)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, minZoom);
        }

        // Check for arrow keys and move camera around
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(new Vector3(0, keyScrollRate, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(new Vector3(0, -keyScrollRate, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(new Vector3(-keyScrollRate, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(new Vector3(keyScrollRate, 0, 0));
        }

        // Mouse edge of screen scrolling and/or click-drag should go here
    }
}