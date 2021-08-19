using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will restrain the object containing this script to the edges of the main cameras field of vision
//In this game, this is used to prevent the Player from going off screen and keep them in the left half of the screen
public class PSBoundariesOrthographic : MonoBehaviour {
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public Transform myBox;

    /*
    Initialize the edges of the screen 
    Find the width and height of the current object to prevent the object from going halfway offscreen
    */
    void Start () {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = myBox.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = myBox.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    /*
    Keep object bound within the cameras field of vision
    In this game, we want the player to only be able to move on the left half of the screen
    */
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        //enable the following line of code instead of the one below it if you want to let the player move around the entire screen
        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, 0 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}