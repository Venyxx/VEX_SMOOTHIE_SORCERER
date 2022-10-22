using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothieMix : MonoBehaviour
{
    public bool hasBanana;
    public bool hasBlueberry;
    public bool hasStrawberry;

    public int foodValue;
    // Start is called before the first frame update
    void Start()
    {
        hasBanana = false;
        hasBlueberry = false;
        hasStrawberry = false;

        foodValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
