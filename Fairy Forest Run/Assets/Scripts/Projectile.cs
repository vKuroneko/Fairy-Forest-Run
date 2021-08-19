using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base Projectile Class
public class Projectile : MonoBehaviour
{

    public void destroySelf()
    {
        Destroy(gameObject);
    }

}
