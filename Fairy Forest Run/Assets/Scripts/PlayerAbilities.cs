using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public float EnergyOne, EnergyTwo;
    public GameObject projectileOne;
    public GameObject Barrier;
    private AbilityReady QReady;
    private AbilityReady EReady;

    private PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GetComponent<PlayerScript>();
        QReady = GameObject.Find("Q Ready").GetComponent<AbilityReady>();
        EReady = GameObject.Find("E Ready").GetComponent<AbilityReady>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UseAbilityOne();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            UseAbilityTwo();
        }

        CheckAbilityReady();
    }

    private void UseAbilityOne()
    {
        if(player.playerEnergy >= EnergyOne)
        {
            var fireball = Instantiate(projectileOne, transform.position, Quaternion.identity);
            player.UseEnergy(EnergyOne);
        }
    }

    private void UseAbilityTwo()
    {
        if(player.playerEnergy >= EnergyTwo)
        {
            if(!Barrier.activeInHierarchy)
            {
                Barrier.SetActive(true);
                player.UseEnergy(EnergyTwo);
            }
        }
    }

    private void CheckAbilityReady()
    {
        if(player.playerEnergy >= EnergyOne)
        {
            QReady.Ready();
        }
        else
        {
            QReady.NotReady();
        }

        if(player.playerEnergy >= EnergyTwo)
        {
            EReady.Ready();
        }
        else
        {
            EReady.NotReady();
        }
    }

}
