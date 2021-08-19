using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointMovement : MonoBehaviour
{
    public float distanceFromBody;  //Distance from player to spawn bullets at
    private Transform player;       //Holds our Player Instance's transform
    //private Vector2 originPoint;

    void Start()
    {
        player =  FindObjectOfType<PlayerScript>().GetComponent<Transform>();
    }

    //Position self in between the player and the mouse at a certain distance from the player
    void Update()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position).normalized;
        transform.position = (player.position + (dir * distanceFromBody));
    }
}
