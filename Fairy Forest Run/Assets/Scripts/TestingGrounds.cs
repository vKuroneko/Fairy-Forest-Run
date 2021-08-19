using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGrounds : MonoBehaviour
{

    public GameObject enemyType1;
    public GameObject enemyType2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            var rando = Random.Range(1,20);
            Vector3 offset = new Vector3(0,rando, 0);
            Instantiate(enemyType1, transform.position + offset, Quaternion.identity);
        }
        if(Input.GetKeyDown("e"))
        {
            var rando = Random.Range(1,20);
            Vector3 offset = new Vector3(0,rando, 0);
            Instantiate(enemyType2, transform.position + offset, Quaternion.identity);
        }
    }
}
