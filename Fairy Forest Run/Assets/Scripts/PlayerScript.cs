using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
 
    [HideInInspector]
    public float playerHealth, playerEnergy, playerHype,
                playerMaxHealth, playerMaxEnergy, playerMaxHype;

    public GameMaster gm;
    public GameObject Fairy;
    public GameObject PauseMenu;

    private float hypeIncreaseInterval; // Rate at which Hype increases


    void Start()
    {
        gm = FindObjectOfType<GameMaster>();

        playerMaxHealth = 100;
        playerMaxEnergy = 100;
        playerMaxHype = 100;
        
        playerHealth = playerMaxHealth;
        playerEnergy = 0;
        playerHype = 0;

        hypeIncreaseInterval = 1/(playerMaxHype/20);//Increase Divisor to slow down or decrease to speed up the rate of Hype increase

        StartCoroutine(IncreaseHype()); //Start Hype Increase at start of game
    }
    
    //Increase the Hype at a given rate
    IEnumerator IncreaseHype()
    {
        while(playerHealth > 0)
        {
            if(playerHype < playerMaxHype){
                playerHype++;
                if(playerHype > playerMaxHype)
                {
                    playerHype = playerMaxHype;
                }
            }
            
            yield return new WaitForSeconds(hypeIncreaseInterval);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Do nothing, needed for collisions
    }

    /*
    Called by other objects when player takes damage
    Calling object will provide the damage amount
    */
    public void TakeDamage(float damage)
    {
        LoseHype();
        playerHealth-= damage;
        if(playerHealth < 1 && Fairy)
        {
            playerHealth = 0;
            Destroy(Fairy);
            PauseMenu.GetComponent<Pause>().GameOver();
        }
        gm.UpdateHealth();
    }

    /*
    Called by other objects when player heals 
    Calling object will provide the heal amount
    */
    public void Heal(float amount)
    {
        if(playerHealth < playerMaxHealth)
        {
            playerHealth+= amount;
            if(playerHealth > playerMaxHealth)
            {
                playerHealth = playerMaxHealth;
            }
        }
        gm.UpdateHealth();
    }

    public void GainEnergy(float amount)
    {
        if(playerEnergy < playerMaxEnergy)
        {
            playerEnergy+= amount;
            if(playerEnergy > playerMaxEnergy)
            {
                playerEnergy = playerMaxEnergy;
            }
        }
        gm.UpdateEnergy();
    }

    public void UseEnergy(float amount)
    {
        if(playerEnergy > 0)
        {
            playerEnergy-= amount;
        }
        else
            playerEnergy = 0;
    }

    /*
    Lose Hype when taking damage
    Amount lost is determined by current ammount
    */
    public void LoseHype()
    {
        if(playerHype > playerMaxHype * 0.75f)
        {
            playerHype = playerMaxHype * 0.50f;
        }
        else
        {
            if(playerHype > playerMaxHype * 0.50f)
            {
                playerHype = playerMaxHype * 0.25f;
            }
            else
            {
                playerHype = 0f;
            }
        }
    }
    
}
