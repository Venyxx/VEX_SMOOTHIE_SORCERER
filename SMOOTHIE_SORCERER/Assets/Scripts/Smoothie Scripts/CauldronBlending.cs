using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CauldronBlending : MonoBehaviour
{
    
        public bool hasBanana;
        public bool hasBlueberry;
        public bool hasStrawberry;
        
        public GameObject StrBanana;
        public GameObject BananaSM;
        public GameObject StrawbSM;

    // Start is called before the first frame update
    public void Start()
    {
       
    }

    public void Update()
    {
    
    }

    public void OnTriggerEnter (Collider col)
    {
       Debug.Log("were hitting the trigger");

         if (col.gameObject.name == "Cube(Clone)")
          {
             hasBanana = true;
             Debug.Log("were hitting the banana");

          }

          if (col.gameObject.name == "Strawberry_export(Clone)")
          {
            hasStrawberry = true;
          }

    }

    public void StrawBanana()
    {
        Instantiate(StrBanana);
    }

    public void Strawberry()
    {
        Instantiate(StrawbSM);
    }

    public void Banana()
    {
        Instantiate(BananaSM);
    }
}
