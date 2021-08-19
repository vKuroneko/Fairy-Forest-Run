using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionBoundary : MonoBehaviour
{
    //Off screen colliders that will tell projectiles to destroy themselves
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerProjectile") || other.CompareTag("EnemyProjectile"))
        {
            other.GetComponent<Projectile>().destroySelf();
        }
    }

}
