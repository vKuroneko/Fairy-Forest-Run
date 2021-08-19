using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityReady : MonoBehaviour
{
    private Image img;
    public Color myColor;

    private void Start() {
        img = GetComponent<Image>();   
        img.color = myColor; 
    }

    public void Ready()
    {
        img.color = myColor;
    }

    public void NotReady()
    {
        img.color = new Color( myColor.r, myColor.g, myColor.b, 0.3f);
    }

}
