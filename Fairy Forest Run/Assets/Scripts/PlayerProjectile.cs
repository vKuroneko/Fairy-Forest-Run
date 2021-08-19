using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    public float speed;
    public float maxoffset;
    private Vector3 myOrigin;
    public float maxDistance;
    private Vector2 moveDirection;
    public float damage;
    public bool destroyOnEnemyContact;


    void Start()
    {
        moveDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        moveDirection = new Vector2(moveDirection.x,moveDirection.y + Random.Range(-maxoffset,maxoffset));
        float rotZ = Mathf.Atan2(moveDirection.y,moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(moveDirection);
        myOrigin = transform.position;

    }

    void Update()
    {
        Move();
        
        var currentDistance = Vector3.SqrMagnitude(transform.position - myOrigin);
        if(currentDistance > maxDistance)
            destroySelf();
    }

    public void SetDirection(float xx, float yy)
    {
        moveDirection = new Vector2(xx,yy);
    }

    void Move()
    {
        transform.position+= (Vector3)moveDirection.normalized * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Enemy") && destroyOnEnemyContact)
            destroySelf();
    }

}
