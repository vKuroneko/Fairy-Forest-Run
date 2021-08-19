using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBatMovement : Enemy
{
    public Transform player;
    public Camera MainCamera;
    public GameObject deathEffect;
    public GameObject EnergyDrop;
    private Vector2 screenBounds;   //4 Edges of the screen
    private Vector3 moveDir;        //Initial direction to move in

    public float speed;
    public float health;
    public float damage;
    //private float LeftBound;      //This would be used in the event of creating a left boundary of movement
    private float moveCounter;      //Length of time we will fly before stopping
    private bool canMove;           //Tells us whether we should move or not
    
    /*
    Find the bounds of the screen
    Find the Player's Transform
    Start off moving and then stop after a random amount of time
    */
    void Start()
    {
        
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        player =  FindObjectOfType<PlayerScript>().GetComponent<Transform>();

        speed = Random.Range(speed-0.5f, speed);
        canMove = true;
        moveCounter = Random.Range(3,5);
        Invoke("StopMoving", moveCounter);
        
    }
    //If we can move and we haven't reached a certain distance on the screen, then move
    void Update()
    {
        if(canMove && transform.position.x > 2)
            Move();
    }

    //If we go above or below the screen, destroy self
    void LateUpdate()
    {
        if(transform.position.y < -screenBounds.y - 1 || transform.position.y > screenBounds.y + 1)
        {
            Destroy(gameObject);
        }
    
    }

    //Take damage when colliding with a player projectile
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("PlayerProjectile"))
            {
                TakeDamage(coll.gameObject.GetComponent<PlayerProjectile>().damage);
            }
    }

    //Move towards the Player
    void Move()
    {
        moveDir = (player.position - transform.position).normalized;
        transform.position+= moveDir * speed * Time.deltaTime;
    }

    //Called when we want to stop moving
    void StopMoving()
    {
        canMove = false;
    }

    //Take damage and if we have no more health, destroy self
    void TakeDamage(float dmg)
    {
        health-= dmg;
        if(health < 1)
        {
            if(Random.Range(0f,1f) < 0.5f)
                Instantiate(EnergyDrop, transform.position, Quaternion.identity);
            DestroySelf();
        }
    }

    //Create our death effect and then destroy ourself
    void DestroySelf()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
