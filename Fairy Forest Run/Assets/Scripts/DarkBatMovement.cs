using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBatMovement : Enemy
{
    
    public GameObject deathEffect;
    public GameObject EnergyDrop;
    private Transform player;
    private Vector2 screenBounds;//Will hold the 4 edges of the screen to know when it has gone offscreen
    private Vector2 moveDir;//direction to move in

    public float speed;
    public float health;
    public float damage;
    public float moveOffset;
    private float LeftBound;//will hold the left edge of the screen to know when to despawn

    /*
    Store reference to the Player
    Find 4 Screen Edges
    Get the direction from our current position to the Player's position
    */
    void Start()
    {
        player =  FindObjectOfType<PlayerScript>().GetComponent<Transform>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        moveDir = (player.position - transform.position).normalized;
        moveDir = new Vector2(moveDir.x,moveDir.y + Random.Range(-moveOffset,moveOffset));
        speed = Random.Range(speed-0.5f, speed+0.5f);
        
    }

    //Move every frame
    void Update()
    {
        Move();
    }

    /*
    Check to see if we are off screen, excluding the right side where enemies spawn from
    If we are offscreen, despawn
    */
    void LateUpdate()
    {
        if(transform.position.x < -screenBounds.x - 2)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < 0 && (transform.position.y < -screenBounds.y - 1 || transform.position.y > screenBounds.y + 1) )
        {
            Destroy(gameObject);
        }
    
    }

    //Take damage and deal damage to player
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("PlayerProjectile"))
            {
                TakeDamage(coll.gameObject.GetComponent<PlayerProjectile>().damage);
            }
        if(coll.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().TakeDamage(damage);
        }
    }

    //Moves current position
    void Move()
    {
        transform.position+= (Vector3)moveDir * speed * Time.deltaTime;
    }

    /*
    Take Damage
    If we have no more health, despawn
    */
    public void TakeDamage(float dmg)
    {
        health-= dmg;
        if(health < 1)
        {
            if(Random.Range(0f,1f) < 0.25f)
                Instantiate(EnergyDrop, transform.position, Quaternion.identity);
            DestroySelf();
        }
    }
    //Create our death effect and despawn
    void DestroySelf()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
