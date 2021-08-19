using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject projectile;   //Holds PlayerProjectile Prefab
    public float maxFireRate;       //Maximum rate of fire when at max Hype
    private float firerate;         //Current rate of fire
    private bool canFire;           //Controls when we can fire
    private PlayerScript player;

    /*
    Start off being able to fire
    Get a reference to the players PlayerScript
    */
    void Start()
    {
        canFire = true;
        player = FindObjectOfType<PlayerScript>();
    }

    /*
    If the Left mouse button is being pressed and we can fire
        Check to see what the current fire rate is. Fire rate varies by amount of Hype the Player has
        Create a projectile
        Call our Reload function at the appropiate speed
        Make sure we can't fire anymore until we reload
    */
    void Update()
    {
        if(Input.GetMouseButton(0) && canFire)
        {
            updateFirerate();
            Shoot();
            Invoke("Reload", firerate);
            canFire = false;
        }
        

    }

    //Create projectile
    void Shoot()
    {
        var fireball = Instantiate(projectile, transform.position, Quaternion.identity);
    }

    //Let Player fire again
    void Reload()
    {
        canFire = true;
    }

    //Change fireRate to a fraction of our maxFireRate depending on amount of Hype Player has
    void updateFirerate()
    {
        if(player.playerHype > player.playerMaxHype * 0.75f)
        {
            firerate = maxFireRate;
        }
        else
        {
            if(player.playerHype > player.playerMaxHype * 0.50f)
            {
                firerate = maxFireRate * 2;
            }
            else
            {
                    if(player.playerHype > player.playerMaxHype * 0.25f)
                    {
                        firerate = maxFireRate * 3;
                    }
                    else
                    {
                        firerate = maxFireRate * 4;
                    }
            }
        }
    }
}
