using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    private PlayerScript player;
    private SpriteRenderer rend;
    private CircleCollider2D coll;
    private bool canMove;
    public float moveSpeed;
    public float timer;
    [HideInInspector]
    public float EnergyAmount;  

    // Start is called before the first frame update
    void Start()
    {
        player =  FindObjectOfType<PlayerScript>();
        if(Random.Range(0f,1f) < 0.25f)
        {
            EnergyAmount = player.playerMaxEnergy/5;
        }
        else
        {
            EnergyAmount = player.playerMaxEnergy/10;
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }

        canMove = false;
        Invoke("StartMovement", timer);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            var target = player.GetComponent<Transform>().position;
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime*moveSpeed);
            moveSpeed += .02f;
        }
    }

    private void StartMovement()
    {
        canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {    
        if(coll.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>().GainEnergy(EnergyAmount);
            destroySelf();
        }
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
