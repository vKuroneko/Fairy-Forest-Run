using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{

    public float damage;
    public float speed;
    private Vector2 moveDirection;
   
    //Move every frame
    void Update()
    {
        Move();
    }

    //called by EnemyShoot script to set initial direction
    public void SetDirection(float xx, float yy)
    {
        moveDirection = new Vector2(xx,yy);
    }

    //Move in our initial direction
    void Move()
    {
        transform.position+= (Vector3)moveDirection.normalized * speed * Time.deltaTime;
    }

    //damage player on collision
    private void OnCollisionEnter2D(Collision2D coll)
    {    
        if(coll.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().TakeDamage(damage);
            //player.GetComponent<PlayerScript>().TakeDamage(damage);
            destroySelf();
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Boundaries"))
        {
            destroySelf();
        }    
    }

}
