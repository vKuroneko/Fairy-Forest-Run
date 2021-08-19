using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTD : MonoBehaviour
{
    public float speed;
    public GameObject myShadow;
    private float moveX;
    private float moveY;
    private Vector2 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        PlayerMove();
        /*if(rb.rotation != 0)
            rb.rotation = 0;*/
        if(transform.rotation != Quaternion.Euler(0,0,0))
            transform.rotation = Quaternion.Euler(0,0,0);
        
        /*
        if(transform.position.y <= Camera.main.transform.position.y - 8 && !myShadow.activeInHierarchy )
        {
            myShadow.SetActive(true);
        }
        else
        {
            if(transform.position.y > Camera.main.transform.position.y - 8 && myShadow.activeInHierarchy)
            {
                myShadow.SetActive(false);
            }
        }
        */
    }

    void PlayerMove()
    {
        moveX = moveY = 0;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))    { moveY = 1f;}

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  { moveY = -1f;}

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  { moveX = -1f;}

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { moveX = 1f;}

        moveDir = new Vector2(moveX, moveY).normalized;

    }

    public void FixedUpdate()
    {
        transform.position+= (Vector3)moveDir * speed * Time.deltaTime;
        //rb.velocity = moveDir * speed;
    }
}
