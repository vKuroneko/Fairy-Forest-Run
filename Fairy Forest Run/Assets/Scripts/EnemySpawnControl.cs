using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControl : MonoBehaviour
{
    public int difficulty;
    public int maxDifficulty;
    [SerializeField] private Enemy[] EnemyType; //Store multiple enemy types in an array that is accessible via inspector 

    private int selectedEnemyType; //Will tell us what enemy to spawn from our array
    private float xOffset;
    private Vector2 screenBounds;   //Holds the edges of the screen so we can know where to spawn enemies

    /*
    Find the screen edges
    xOffset will tell us how far offscreen to spawn the enemy
    */
    private void Start()
    {
     screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
     xOffset = screenBounds.x/2;
    }

    /*
    Spawn enemies if there are currently no enemies on screen
    Let there be a small chance to spawn enemies even if there are already enemies on screen up to a limit
    */
    void Update()
    {
        /*For testing purposes
        if(Input.GetKeyDown("q"))
        {
            SpawnEnemy();
        }
        */
        if(FindObjectOfType<Enemy>() == null)
        {
            SpawnEnemy();
        }

        if(Random.Range(0f,2f) < 0.001)
        {
            SpawnEnemy();
        }


    }

    //Select and spawn a random enemy type
    void SpawnEnemy()
    {
        if(FindObjectsOfType<Enemy>().Length > 3)
            return;

        selectedEnemyType = Random.Range(0, EnemyType.Length);
        switch (selectedEnemyType)
        {
            case 0: SpawnBats();
            break;
            
            case 1: SpawnBatsTwo();
            break;
            
            default: SpawnBats();
            break;
        }
    }

    //Spawn 5 DarkBat prefabs
    void SpawnBats()
    {
        var numEnemies = 5;
        for(int i = 0; i < numEnemies; i++)
        {
            var spawnY = Random.Range(-screenBounds.y,screenBounds.y);
            var spawnX = Random.Range(screenBounds.x,screenBounds.x + xOffset);
            Vector3 spawnPoint = new Vector3(spawnX,spawnY,0);
            Instantiate(EnemyType[selectedEnemyType], spawnPoint, Quaternion.identity);
        }
    }

    //Spawn 5 ShootingBat prefabs
    void SpawnBatsTwo()
    {
        var numEnemies = 5;
        for(int i = 0; i < numEnemies; i++)
        {
            var spawnY = Random.Range(-screenBounds.y,screenBounds.y);
            var spawnX = Random.Range(screenBounds.x,screenBounds.x + xOffset);
            Vector3 spawnPoint = new Vector3(spawnX,spawnY,0);
            Instantiate(EnemyType[selectedEnemyType], spawnPoint, Quaternion.identity);
        }
    }

}
