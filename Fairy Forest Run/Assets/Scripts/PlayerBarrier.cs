using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    public float lifetime;
    private float timer;
    // Start is called before the first frame update
    void OnEnable()
    {
        timer = lifetime;
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while(timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }
        gameObject.SetActive(false);
    }
}
