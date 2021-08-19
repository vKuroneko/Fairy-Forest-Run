using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private Transform player;
    private Text health;
    private Text energy;
    private Text hype;
    private Slider healthBar;
    private Slider energyBar;
    private Slider hypeBar;

    public GameObject EnemySpawner;
    public GameObject LoadingUI;

    /*
    Store reference to Player
    Initialize the maximum values of the on screen bars
    Initialize the current Player health
    
    */


    IEnumerator Start() {

        yield return new WaitForSeconds(1);
        
        if(player == null)
        {
        player =  FindObjectOfType<PlayerScript>().GetComponent<Transform>();
        health = GameObject.Find("Health Display").GetComponent<Text>();
        energy = GameObject.Find("Energy Display").GetComponent<Text>();
        hype = GameObject.Find("Hype Display").GetComponent<Text>();
        healthBar = GameObject.Find("Health Bar").GetComponent<Slider>();
        energyBar = GameObject.Find("Energy Bar").GetComponent<Slider>();
        hypeBar = GameObject.Find("Hype Bar").GetComponent<Slider>();

        healthBar.maxValue = player.GetComponent<PlayerScript>().playerMaxHealth;
        energyBar.maxValue = player.GetComponent<PlayerScript>().playerMaxEnergy;
        hypeBar.maxValue = player.GetComponent<PlayerScript>().playerMaxHype;


        UpdateHealth();
        }
        LoadingUI.SetActive(false);
        EnemySpawner.SetActive(true);
    }


    //If the player exists, update the energy and hype bars to current values
    void Update()
    {
        if(player != null) {
            UpdateEnergy();
            UpdateHype();
        }
    }
    //Called whenever the Player heals or takes damage
    public void UpdateHealth()
    {
        healthBar.value = player.GetComponent<PlayerScript>().playerHealth;
        health.text = "Health: " + player.GetComponent<PlayerScript>().playerHealth.ToString();
    }

    public void UpdateEnergy()
    {
        energyBar.value = player.GetComponent<PlayerScript>().playerEnergy;
        energy.text = "Energy: " + player.GetComponent<PlayerScript>().playerEnergy.ToString();
    }

    public void UpdateHype()
    {
        hypeBar.value = player.GetComponent<PlayerScript>().playerHype;
        hype.text = "Hype:   " + player.GetComponent<PlayerScript>().playerHype.ToString();
    }

}
