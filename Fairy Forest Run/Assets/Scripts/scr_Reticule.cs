using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Reticule : MonoBehaviour
{
    private Vector2 mousepos;

    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousepos.x,mousepos.y,0);


    }
}