using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] public bool wantStrawberry;
    [SerializeField] public bool wantBlueberry;
    [SerializeField] public bool wantBanana;
    int rInt;
    
    // Start is called before the first frame update
    void Start()
    {
         rInt = 2;
        //random not working idk
    }

    // Update is called once per frame
    void Update()
    {
        //right now just for everything
        if (rInt < 10)
        {
            //Debug.Log("customer wants strawberry banana");
            wantStrawberry = true;
            wantBanana = true;
            wantBlueberry = false;
        }
    }
}
