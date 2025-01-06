using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Camera MainCamera;
    public Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        Setup();
    }

    /// <summary>
    /// Gets all the data we need
    /// </summary>
    private void Setup()
    {
        screenBounds    = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth     = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight    = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    /// <summary>
    /// Late Update executes after update, so will not cause any conflicts with anything running in the Update()
    /// </summary>
    void LateUpdate()
    {
        SettingBoundaries();
    }

    /// <summary>
    /// Clamps the player to stay in the boundaries of the screen.
    /// </summary>
    private void SettingBoundaries()
    {
        Vector3 viewPos     = transform.position;
        viewPos.x           = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y           = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position  = viewPos;
    }
}
