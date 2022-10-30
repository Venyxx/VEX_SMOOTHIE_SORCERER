using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomerOrder : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] public bool wantStrawberry;
    [SerializeField] public bool wantBlueberry;
    [SerializeField] public bool wantBanana;

     [Header("Potion")]
    [SerializeField] public bool wantInvis;
    [SerializeField] public bool wantPolymorph;
    [SerializeField] public bool wantSpeed;
    private bool choseOrder;
    private bool chosePotion;

    int xPotion;
     int xOrder;
    
    // Start is called before the first frame update
    void Start()
    {
         xOrder = UnityEngine.Random.Range(1, 3);
         xPotion = UnityEngine.Random.Range(1, 3);
        choseOrder = false;
        chosePotion = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!choseOrder)
        {
            chooseOrder();
        }

          if (!chosePotion)
        {
            choosePotion();
        }

    }

    void choosePotion ()
    {
        if (xPotion == 1)
        {
            Debug.Log("customer wants invis");
            wantInvis = true;


        } else if  (xPotion == 2)
        {
            Debug.Log("customer wants polymorph");
            wantPolymorph = true;
        }
        else if  (xPotion == 3)
        {
            Debug.Log("customer wants speed");
            wantSpeed = true;
    
        }

        chosePotion = true;
    }
    void chooseOrder()
    {
        if (xOrder == 1)
        {
            Debug.Log("customer wants strawberry banana");
            wantStrawberry = true;
            wantBanana = true;
            wantBlueberry = false;

        } else if  (xOrder == 2)
        {
            Debug.Log("customer wants strawberry blueberry");
            wantStrawberry = true;
            wantBanana = false;
            wantBlueberry = true;
        }
        else if  (xOrder == 3)
        {
            Debug.Log("customer wants banana blueberry");
            wantStrawberry = false;
            wantBanana = true;
            wantBlueberry = true;
        }

        choseOrder = true;
    }
}
