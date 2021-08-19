using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;   //holds the EnemyProjectile Prefab
    public float firerate;          //Reload speed
    public float bulletSpeed;       //speed of projectile
    public float bulletOffset;
    private bool canFire;           // check to see if we can fire

    //Start off able to fire
    void Start()
    {
        canFire = true;
        firerate = Random.Range(firerate - 0.1f, firerate + 0.1f);
    }

    /*
    Check if we can fire
    If true, then fire and then wait to fire again
    */
    void Update()
    {

        if(canFire)
        {
            Shoot();
            Invoke("Reload", firerate);
            canFire = false;
        }
        

    }
    //Create a projectile and send in direction of player
    void Shoot()
    {
        var fireball = Instantiate(projectile, transform.position, Quaternion.identity);
        Vector2 target = GetComponent<ShooterBatMovement>().player.position - transform.position;
        target = target + new Vector2(target.x,target.y + Random.Range(-bulletOffset,bulletOffset));
        fireball.GetComponent<EnemyProjectile>().SetDirection(target.x,target.y);
    }

    //Let us fire again
    void Reload()
    {
        canFire = true;
    }
}
